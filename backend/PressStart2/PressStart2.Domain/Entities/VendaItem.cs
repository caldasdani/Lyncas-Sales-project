using PressStart2.Domain.Entities;
using PressStart2.Domain.Entities.Contracts;
using System;
using System.Security.Cryptography.X509Certificates;

public class VendaItem : EntidadeBase // a classe vendaitem está herdando oq contem na EntidadeBase.
{
	public Guid VendaId { get; private set; }
	public string? DescricaoItem { get; private set; }
	public decimal ValorUnitario { get; private set; }
	public int Quantidade { get; private set; }
	public decimal ValorTotal { get; private set; }

	private VendaItem() { }

	public VendaItem (string? descricaoItem, decimal valorUnitario, int quantidade, decimal valorTotal)
	{
		DescricaoItem = descricaoItem;
		ValorUnitario = valorUnitario;
		Quantidade = quantidade;
		ValorTotal = valorTotal;

		this.AdicionarVendaItemContract();
	}
	public void Atualizar(string? descricaoItem, decimal valorUnitario, int quantidade, decimal valorTotal)
	{
        DescricaoItem = descricaoItem;
        ValorUnitario = valorUnitario;
        Quantidade = quantidade;
        ValorTotal = valorTotal;

		this.AtualizarVendaItemContract();
    }
}
