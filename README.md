# Webservice-1.5-csharp

Integração em C# com o Webservice Cielo 1.5

## Setup

Se preferir você pode pegar a versão mais recente diretamente do [pacote disponível](https://www.nuget.org/packages/CieloOficial/) na galeria do NuGet.

> PM Install-Package CieloOficial


## Criando uma transação

```csharp
using CieloEcommerce;
//...
String mid = "1006993069";
String key = "25fbb99741c739dd84d7b06ec78c9bac718838630f30b112d033ce2e621b34f3";

Cielo cielo = new Cielo (mid, key, Cielo.TEST);

Holder holder = cielo.holder ("4012001038443335", "2018", "05", "123");
holder.name = "Fulano Portador da Silva";

Random randomOrder = new Random ();

Order order = cielo.order (randomOrder.Next (1000, 10000).ToString (), 10000);
PaymentMethod paymentMethod = cielo.paymentMethod (PaymentMethod.VISA, PaymentMethod.CREDITO_A_VISTA);

Transaction transaction = cielo.transactionRequest (
	holder,
	order,
	paymentMethod,
	"http://localhost/cielo",
	Transaction.AuthorizationMethod.AUTHORIZE_WITHOUT_AUTHENTICATION,
	false
);

//...
```

## Criando uma transação e enviando para autorização

```csharp
using CieloEcommerce;
//...

try {
	Transaction transaction = cielo.transactionRequest (
		                          holder,
		                          order,
		                          paymentMethod,
		                          "http://localhost/cielo",
		                          Transaction.AuthorizationMethod.AUTHORIZE_WITHOUT_AUTHENTICATION,
		                          false
	                          );

	if (transaction.authorization != null && transaction.authorization.lr == "00") {
		Console.Write ("Transação autorizada com sucesso. TID=");
		Console.WriteLine (transaction.tid);
	}
} catch (CieloException e) {
	Console.WriteLine ("Opz..");
	Console.WriteLine (e.Code);
	Console.WriteLine (e.Message);
}
```

## Exemplo de consulta

```csharp
using CieloEcommerce;
//...


try {
	transaction = cielo.consultationRequest ("1006993069000654F07A"); // tid da transação
} catch (CieloException e) {
	Console.WriteLine (e.Code);
	Console.WriteLine (e.Message);
}
```

## Cancelamento total de uma transação

```csharp
using CieloEcommerce;
//...


try {
	transaction = cielo.cancellationRequest (transaction);
} catch (CieloException e) {
	Console.WriteLine (e.Code);
	Console.WriteLine (e.Message);
}
```

## Captura total de uma transação

```csharp
using CieloEcommerce;
//...


try {
	transaction = cielo.captureRequest (transaction);
} catch (CieloException e) {
	Console.WriteLine (e.Code);
	Console.WriteLine (e.Message);
}
```

## Captura parcial de uma transação

```csharp
using CieloEcommerce;
//...


try {
	transaction = cielo.captureRequest (transaction, 10000);
} catch (CieloException e) {
	Console.WriteLine (e.Code);
	Console.WriteLine (e.Message);
}
```
