export function formattingDate(date) {
    const newDate = new Date(date);
    const formatted = new Intl.DateTimeFormat("pt-br").format(newDate);
    return formatted;
  }

  export function formattingCurrency(currency) {
    const formatted = new Intl.NumberFormat("pt-BR", {
      style: "currency",
      currency: "BRL",
    }).format(currency);
    return formatted;
  }