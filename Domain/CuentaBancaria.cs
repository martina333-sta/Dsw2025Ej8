namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public  string Numero { get; protected set; }
    public  decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; } 
    public  decimal TasaDeInteres { get; protected set; }
    public  decimal LimiteDeDescubierto { get; protected set; }
    public  decimal Comision { get; protected set; }
    public  string[] Titulares { get; protected set;  }

    public CuentaBancaria(string numero, decimal saldo,  string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }
 
    public abstract void Depositar(decimal monto);
    public abstract void Retirar(decimal monto);
    public abstract void AplicarInteres();


}
