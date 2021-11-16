using System;

namespace ej1
{
    //     Vamos a construir un programa que calcule y muestre el precio de un terreno dependiendo de su tamaño, del tipo de
    // terreno que se quiera comprar y de un descuento aplicado.
    // Necesitaremos saber el tipo de terreno (urbano o rústico), controlando que la entrada sea correcta e
    // independientemente de mayúsculas o minúsculas. También recogeremos la información del largo y ancho del terreno
    // (float), para calcular los metros cuadrados (largo * ancho).
    // Con toda la información calcularemos el precio de coste total, teniendo en cuenta que: el terreno rústico cuesta 20 euros el
    // m2 y el urbano 150 euros el m2. Se aplicará un descuento según las siguientes premisas:
    // Si el terreno tiene más de 400 metros cuadrados se hace un descuento del 10% si el terreno tiene más de 500 metros
    // cuadrados el descuento es del 17%.
    // ✋ Nota: Realizar el ejercicio con switch when. Tendrás que crear los métodos necesarios para conseguir una buena    // programación modular.
    class Program
    {
        static void Main(string[] args)
        {
            string tipoTerreno;
            do
            {
                System.Console.Write("Indica tipo de terreno(rustico/urbano): ");
                tipoTerreno = Console.ReadLine().ToUpper();
            } while (tipoTerreno != "RUSTICO" && tipoTerreno != "URBANO");

            System.Console.Write("Introduce ancho terreno: ");
            float ancho = float.Parse(Console.ReadLine());
            System.Console.Write("Introduce largo terreno: ");
            float largo = float.Parse(Console.ReadLine());

            string texto = "";
            double precioFinca;
            float areaTerreno = ancho * largo;
            const double PRECIO_TERRENO_URBANO=150;
            const double PRECIO_TERRENO_RUSTICO=20;


            switch (tipoTerreno)
            {
                case "URBANO" when (areaTerreno) > 500:
                    precioFinca = areaTerreno * PRECIO_TERRENO_URBANO * 0.83;
                    texto = $"El terreno mide mas de 500 m2 y se le hace un descueto del 17%\n{areaTerreno} m2 cuesta {precioFinca}";
                    break;
                case "URBANO" when (areaTerreno) > 400:
                    precioFinca = areaTerreno * PRECIO_TERRENO_URBANO * 0.90;
                    texto = $"El terreno mide mas de 400 m2 y se le hace un descueto del 10%\n{areaTerreno} m2 cuesta {precioFinca}";
                    break;
                case "URBANO":
                    precioFinca = areaTerreno * PRECIO_TERRENO_URBANO;
                    break;

               case "RUSTICO" when (areaTerreno) > 500:
                    precioFinca = areaTerreno * PRECIO_TERRENO_RUSTICO * 0.83;
                    texto = $"El terreno mide mas de 500 m2 y se le hace un descueto del 17%\n{areaTerreno} m2 cuesta {precioFinca}";
                    break;
                case "RUSTICO" when (areaTerreno) > 400:
                    precioFinca = areaTerreno * PRECIO_TERRENO_RUSTICO * 0.90;
                    texto = $"El terreno mide mas de 400 m2 y se le hace un descueto del 10%\n{areaTerreno} m2 cuesta {precioFinca}";
                    break;
                case "RUSTICO":
                    precioFinca = areaTerreno * PRECIO_TERRENO_RUSTICO;
                    break;
                default:
                    texto = "";
                    break;
            }
            System.Console.WriteLine(texto);



        }
    }
}
