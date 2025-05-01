namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public CajaDeAhorro(string numero, decimal saldo, string[] titulares, decimal tasaDeInteres) : base(numero, saldo, titulares)
        {
            TasaDeInteres = tasaDeInteres;
        }
        public override void Depositar(decimal monto) { 
            Saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            Saldo -= monto;
            if ( Saldo<0)
                Estado=Estado.Suspendida;
            
                
            }
        public override void AplicarInteres()
        {
            Saldo += Saldo * TasaDeInteres;
        }
        
    }
}

