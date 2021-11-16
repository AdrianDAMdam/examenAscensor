using System;

namespace ej2
{
    class Program
    {
        const short NUMEROPLANTAS = 7;
        const short NUMEROLOCALESPLANTA = 6;
        const short EMPLEADOSPORLOCAL = 5;
        const short VISITASMAXIMAS = 10;
        const short VISITASMINIMAS = 5;
        const short PORCENTAJEUSOASCENSOR = 2;
        static short PideAscensor()
        {
            short planta;
            do
            {
                System.Console.Write("En que planta estas: ");
                planta = short.Parse(Console.ReadLine());
                if (planta > 7 || planta < 0)
                    System.Console.WriteLine("Introduce planta valida");
            } while (planta > 7 || planta < 0);

            return planta;
        }
        static float PersonasQuePuedeHaberEnElEdificio()
        {
            int locales = NUMEROPLANTAS * NUMEROLOCALESPLANTA;
            int personasEdificio = locales * EMPLEADOSPORLOCAL;
            Random aleatorio = new Random();

            int personasEdificioHoraPunta = locales * aleatorio.Next(VISITASMINIMAS, VISITASMAXIMAS + 1) + personasEdificio;
            int personasEdificioHoraNormal = personasEdificio + aleatorio.Next(-personasEdificio * 5 / 100, personasEdificio * 100 / 100);
            float personasQuePuedenEstarUsandoAscensor = personasEdificio * (PORCENTAJEUSOASCENSOR / 100f);
            return personasQuePuedenEstarUsandoAscensor;
        }
        static bool EstaLibre()
        {
            float personasQuePuedenEstarUsandoAscensor = PersonasQuePuedeHaberEnElEdificio();
            bool esLibre;
            Random semilla = new Random();
            if (semilla.Next(0, (int)personasQuePuedenEstarUsandoAscensor) > personasQuePuedenEstarUsandoAscensor / 2)
                esLibre = true;
            else
                esLibre = false;

            return esLibre;
        }
        static int PlantaPardo(int planta)
        {
            int plantaPardo;
            do
            {
                Random semilla = new Random();
                plantaPardo = semilla.Next(0, NUMEROPLANTAS + 1);
            } while (planta == plantaPardo);

            return plantaPardo;
        }
        static void SubePlanta(int plantaParado, int planta)
        {
            string texto = "";
            while (planta > plantaParado)
            {
                texto = $"Ascensor en planta - {plantaParado} - y subiendo...";
                plantaParado += 1;
                System.Console.WriteLine(texto);
                System.Threading.Thread.Sleep(1500);
            }
            HaLLegadoAPlanta(planta);
        }
        static void BajaPlanta(int plantaParado, int planta)
        {
            string texto = "";
            while (planta > plantaParado)
            {
                texto = $"Ascensor en planta - {plantaParado} - y bajando...";
                plantaParado += 1;
                System.Console.WriteLine(texto);
                System.Threading.Thread.Sleep(1000);
            }
            System.Console.WriteLine();
            HaLLegadoAPlanta(planta);

        }
        static void HaLLegadoAPlanta(int planta)
        {
            string texto = $"El ascensor ya ha llegado a la planta {planta}, puede entrar";
            System.Console.WriteLine(texto);
        }
        static void LlegaAscensor(int plantaParado, int planta)
        {
            if (planta > plantaParado)
            {
                SubePlanta(plantaParado, planta);

            }
            else if (planta < plantaParado)
            {
                BajaPlanta(plantaParado, planta);

            }
            else
            {
                HaLLegadoAPlanta(planta);
            }

        }
        static void EsperaAlAscensor(int planta)
        {
            bool esLibre;
            string texto;
            do
            {
                esLibre = EstaLibre();
                texto = (esLibre ? "El ascenso esta libre" : "El ascensor no esta libre.");
                System.Threading.Thread.Sleep(500);
                System.Console.WriteLine(texto);
            } while (!esLibre);
            int plantaParado = PlantaPardo(planta);
            LlegaAscensor(plantaParado, planta);



        }
        static void Main(string[] args)
        {

            short planta = PideAscensor();
            EsperaAlAscensor(planta);
            //pueba cosas git
            

        }


    }
}
