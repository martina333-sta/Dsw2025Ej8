using Dsw2025Ej8.Domain;
namespace Dsw2025Ej8
{
    class Program
    {
        static void Main()
        {
            var cuentas = new List<CuentaBancaria>();

            var caja1 = new CajaDeAhorro("CA-001", 1000m, new[] { "Martina", "Catalina" })
            {
                TasaDeInteres = 0.03m
            };

            var caja2 = new CajaDeAhorro("CA-002", 300m, new[] { "Mia", "Mariano" })
            {
                TasaDeInteres = 0.04m
            };

            var corriente1 = new CuentaCorriente("CC-001", 500m, new[] { "Nazarena" })
            { Comision = 20m, TasaDeInteres = 0.015m, LimiteDeDescubierto = 200m };

            var corriente2 = new CuentaCorriente("CC-002", 150m, new[] { "Julio", "Cristina" })
            { Comision = 15m, TasaDeInteres = 0.02m, LimiteDeDescubierto = 100m };

            cuentas.Add( caja1 );
            cuentas.Add( caja2 );
            cuentas.Add(corriente1);
            cuentas.Add(corriente2);

            Console.WriteLine("--------OPERACIONES--------");
            foreach(var cuenta in cuentas)
            {
                try
                {
                    cuenta.Depositar(200);
                    cuenta.Retirar(150);
                    cuenta.AplicarInteres();
                    cuenta.Depositar(0);

                }
                catch (MontoNoValido ex)
                {
                    Console.WriteLine($"[Error - Monto no valido]{ex.Message} ");
                }

                catch (CuentaNoActiva ex)
                {
                    Console.WriteLine($"[Error - Cuenta no activa] {ex.Message}");
                }

                catch (SaldoInsuficiente ex)
                {
                    Console.WriteLine($"[Error - Saldo Insuficiente]{ex.Message}");
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"[Excepción capturada] {ex.Message}");
                }

                try
                {
                    cuenta.Retirar(10000);
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"[Excepcion capturada]{ex.Message}");
                }
            }

            Console.WriteLine("------RESUMEN DE CUENTAS------");

                foreach(var cuenta in cuentas)
            {
                var resumen = new
                {
                    Numero = cuenta.Numero,
                    Tipo = cuenta.GetType().Name,
                    Saldo = cuenta.Saldo,
                    Estado = cuenta.Estado.ToString()

                };

                Console.WriteLine($"Cuenta: {resumen.Numero}, Tipo: {resumen.Tipo}, Saldo: {resumen.Saldo:C}, Estado: {resumen.Estado}");
            }
        }

    }
}
