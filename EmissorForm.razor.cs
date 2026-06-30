using Microsoft.AspNetCore.Components;
using Pms.Components.Pages.Emissores.Models;
using System.Text.Json;

namespace Pms.Components.Pages.Emissores.Components;

public partial class EmissorForm : ComponentBase
{
    [Parameter] public EmissorModel Model { get; set; }
    [Parameter] public EventCallback OnSaved { get; set; }
    [Inject] private TituloBancarioEmissorRepository Repo { get; set; }

    private List<ValorOption> ValorOpcoes = [
        new ValorOption(1, "AA+"),
        new ValorOption(2, "AA"),
        new ValorOption(3, "BB+"),
        new ValorOption(4, "BB"),
     ];

    private List<FonteOption> FonteOpcoes = [
        new FonteOption(1, "AGORA"),
        new FonteOption(2, "TESOURARIA"),
     ];

    private int TotalDeFontesDisponiveis => Model.Ratings.Count == 0
            ? 1 :
            FonteOpcoes.Count - Model.Ratings.Count;

    async Task HandleSubmit()
    {
        await Repo.Salvar(Model);
        await OnSaved.InvokeAsync();
    }

    private void HandleInput(ChangeEventArgs e)
    {
        var input = e.Value?.ToString() ?? "";

        var apenasAlfanumericos = new string(input.Where(char.IsLetterOrDigit).ToArray());

        if (apenasAlfanumericos.Length > 14)
            apenasAlfanumericos = apenasAlfanumericos.Substring(0, 14);

        Model.Cnpj = AplicarMascara(apenasAlfanumericos);
    }

    private string AplicarMascara(string valor)
    {
        if (valor.Length <= 2) return valor;
        if (valor.Length <= 5) return valor.Insert(2, ".");
        if (valor.Length <= 8) 
            return $"{valor.Substring(0, 2)}.{valor.Substring(2, 3)}.{valor.Substring(5)}";
        if (valor.Length <= 12) 
            return $"{valor.Substring(0, 2)}.{valor.Substring(2, 3)}.{valor.Substring(5, 3)}/{valor.Substring(8)}";

        return $"{valor.Substring(0, 2)}.{valor.Substring(2, 3)}.{valor.Substring(5, 3)}/{valor.Substring(8, 4)}-{valor.Substring(12)}";
    }

    private void RemoverRating(RatingModel rating)
    {
        Model.Ratings.Remove(rating);
    }

    private void AdicionarRating()
    {
        var ratingInvalido = Model.Ratings.Any(r => r.Invalido());
        var ratingDuplicado = Model.Ratings.GroupBy(r => r.Fonte).Any(g => g.Count() > 1);
        if (ratingInvalido || ratingDuplicado) return;

        var novoRating = new RatingModel();

        var fontesJaSelecionadas = Model.Ratings.Select(r => r.Fonte).ToList();
        novoRating.FonteOpcoes = FonteOpcoes
            .Select(f => new FonteOption(f.Valor, f.Descricao)
            {
                NaoDisponivel = fontesJaSelecionadas.Contains(f.Valor)
            }
            ).ToList();

        if (TotalDeFontesDisponiveis > 0)
        {
            Model.Ratings.Add(novoRating);
        }
    }

    private Task SalvarAsync()
    {
        Console.WriteLine($"Model: {JsonSerializer.Serialize(Model)}");
        
        return Task.CompletedTask;
    }
}
