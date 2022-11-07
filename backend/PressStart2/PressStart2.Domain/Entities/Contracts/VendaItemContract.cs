using prmToolkit.NotificationPattern;

namespace PressStart2.Domain.Entities.Contracts
{
    public static class VendaItemContract
    {
        public static void AdicionarVendaItemContract(this VendaItem vendaitem)
        {
            new AddNotifications<VendaItem>(vendaitem)
                .IfNullOrInvalidLength(p => p.DescricaoItem, 1, 280)
                .IfLowerOrEqualsThan(p => p.ValorUnitario, 0)
                .IfLowerOrEqualsThan(p => p.ValorTotal, 0)
                .IfLowerOrEqualsThan(p => p.Quantidade, 0);
        }
        public static void AtualizarVendaItemContract(this VendaItem vendaitem)
        {
            new AddNotifications<VendaItem>(vendaitem)
               .IfNullOrInvalidLength(p => p.DescricaoItem, 1, 280)
               .IfLowerOrEqualsThan(p => p.ValorUnitario, 0)
               .IfLowerOrEqualsThan(p => p.ValorTotal, 0)
               .IfLowerOrEqualsThan(p => p.Quantidade, 0);
        }
    }
}
