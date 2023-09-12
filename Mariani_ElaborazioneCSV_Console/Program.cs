using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elaborazione_CSV;

namespace Mariani_ElaborazioneCSV_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();

            int scelta = 0;

            do
            {
                Console.WriteLine("Benvenuto nell'elaborazione CSV");
                Console.WriteLine("Cosa desideri fare?\n");
                Console.WriteLine("1 - Start\n2 - Contacampi\n3 - Lunghezza Massima\n4 - Dimensione Fissa\n5 - Aggiunta\n6 - Visualizza\n7 - Ricerca\n8 - Modifica\n9 - Cancella\n");
                scelta = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (scelta)
                {
                    case 1:
                        Azione1();

                        break;
                    case 2:
                        Azione2();
                        break;
                    case 3:
                        Azione3();
                        break;
                    case 4:
                        Azione4();
                        break;
                    case 5:
                        Azione5();
                        break;
                    case 6:
                        Azione6();
                        break;
                    case 7:
                        Azione7();
                        break;
                    case 8:
                        Azione8();
                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("Inserire un Opzione Valida");
                        break;
                }
            } while (scelta != 0);
            
        }

        static void Start()
        {
            int giusto = ElaborazioneCSV.Azione1();
            if (giusto == 1)
            {
                Console.WriteLine("Caricare un file in bin/debug");
                Console.ReadLine();
            }
            
            ElaborazioneCSV.Azione4();
        }

        private static int Ricerca(string parola)
        {
            StreamReader reader = new StreamReader("mariani1.csv");
            string s;
            int i = 0;
            s = reader.ReadLine();
            while (s != null)
            {

                String[] split = s.Split(';');
                String[] split1 = split[Lunghezza() - 1].Split(' ');

                if (split1[0] == parola)
                {
                    reader.Close();
                    return i;
                }

                i++;
                s = reader.ReadLine();

            }
            reader.Close();
            return -1;
        }

        private static int Lunghezza()
        {
            string s;
            int count = 0;
            StreamReader reader = new StreamReader("mariani1.csv");
            s = reader.ReadLine();
            reader.Close();
            return count = s.Split(';').Length;

        }
        static void Azione1()
        {
            ElaborazioneCSV.Azione1();
            Console.WriteLine("Azione eseguita correttamente");
        }

        static void Azione2()
        {
            Console.WriteLine("In un record ci sono " + ElaborazioneCSV.Azione2() + " campi");
        }

        static void Azione3()
        {
            int[] ints = new int[ElaborazioneCSV.Azione2()];
            int temp;
            ints = ElaborazioneCSV.Azione3Avanzato();

            StreamWriter writer = new StreamWriter("temp.txt", append: false);
            writer.WriteLine("In un Record ci sono massimo " + ElaborazioneCSV.Azione3() + " caratteri\n");
            for (int i = 0; i < ElaborazioneCSV.Azione2(); i++)
            {
                temp = i + 1;
                writer.WriteLine("Nel " + temp + " campo ci sono massimo " + ints[i] + " caratteri");
            }
            writer.Close();
            StreamReader reader = new StreamReader("temp.txt");
            string s = "";
            while ((s = reader.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
            reader.Close();
        }

        static void Azione4()
        {
            ElaborazioneCSV.Azione4();
            Console.WriteLine("Azione eseguita correttamente");
        }

        static void Azione8()
        {
            string logicoString;
            Console.WriteLine("Inserisci l'anno: ");
            string parola1 = Console.ReadLine().ToString();
            Console.WriteLine("Inserisci la regione: ");
            string parola2 = Console.ReadLine().ToString();
            Console.WriteLine("Inserisci il tasso femmine: ");
            string parola3 = Console.ReadLine().ToString();
            Console.WriteLine("Inserisci il tasso maschi: ");
            string parola4 = Console.ReadLine().ToString();
            Console.WriteLine("Inserisci il tasso univoco: ");
            string parola5 = Console.ReadLine().ToString();
            Console.WriteLine("Inserisci valore randomico: ");
            string parola6 = Console.ReadLine().ToString();
            Console.WriteLine("Inserisci true o false: ");
            string parola7 = Console.ReadLine().ToString();
            Console.WriteLine("Inserisci la riga: ");
            string parola8 = Console.ReadLine().ToString();

            if (string.IsNullOrWhiteSpace(parola1) || string.IsNullOrWhiteSpace(parola2) || string.IsNullOrWhiteSpace(parola3) || string.IsNullOrWhiteSpace(parola4) || string.IsNullOrWhiteSpace(parola5) || string.IsNullOrWhiteSpace(parola6) || string.IsNullOrWhiteSpace(parola7))
            {
                Console.WriteLine("Assicurati che tutti i campi siano riempiti");
                return;
            }

            bool isAnnoValid = int.TryParse(parola1, out int anno);
            bool isTfemmValid = float.TryParse(parola3, out float t_femm);
            bool isTmascValid = float.TryParse(parola4, out float t_masc);
            bool isTbothValid = float.TryParse(parola5, out float t_both);
            bool isValRandValid = int.TryParse(parola6, out int val_rand);
            bool isLogicoValid = bool.TryParse(parola7, out bool logico);
            bool isRigavalid = int.TryParse(parola8, out int riga);

            if (isAnnoValid && isTfemmValid && isTmascValid && isTbothValid && isValRandValid && isLogicoValid)
            {
                if (logico == false)
                    logicoString = "false";
                else
                    logicoString = "true";

                string regione = parola2;
                int rigaAsd = Ricerca(riga.ToString());
                ElaborazioneCSV.Azione8(anno, regione, t_femm, t_masc, t_both, val_rand, logicoString, riga);
                // Message Box with title and icon
                Console.WriteLine("Azione eseguita correttamente");
            }
            else
            {
                Console.WriteLine("Assicurati che tutti i dati in input siano nel formato corretto");
            }
        }

        private static void Azione6()
        {
            string s;
            int i = 0;
            StreamReader reader = new StreamReader("mariani1.csv");

            s = reader.ReadLine();

            while (s != null)
            {
                String[] split = s.Split(';');
                if (split[6] == "false")
                {
                    Console.WriteLine($"{split[0]};{split[1]};{split[4]}");
                }

                i++;
                s = reader.ReadLine();
            }

            reader.Close();
        }

        private static void Azione7()
        {
            Console.WriteLine("Inserire la riga");
            string parola1 = Console.ReadLine();
            int linea = ElaborazioneCSV.Azione7(parola1);
            if (linea != -1)
            {
                Console.WriteLine("La tua ricerca è stata individuata nella riga " + linea);
            }
            else
            {
                Console.WriteLine("La tua ricerca non ha avuto risultati");
            }
        }

        private static void Azione5()
        {
            string logicoString;
            Console.WriteLine("Inserisci l'anno: ");
            string parola1 = Console.ReadLine().ToString();
            Console.WriteLine("Inserisci la regione: ");
            string parola2 = Console.ReadLine().ToString();
            Console.WriteLine("Inserisci il tasso femmine: ");
            string parola3 = Console.ReadLine().ToString();
            Console.WriteLine("Inserisci il tasso maschi: ");
            string parola4 = Console.ReadLine().ToString();
            Console.WriteLine("Inserisci il tasso univoco: ");
            string parola5 = Console.ReadLine().ToString();
            Console.WriteLine("Inserisci valore randomico: ");
            string parola6 = Console.ReadLine().ToString();
            Console.WriteLine("Inserisci true o false: ");
            string parola7 = Console.ReadLine().ToString();

            string anno = parola1;

            if (string.IsNullOrWhiteSpace(parola1) || string.IsNullOrWhiteSpace(parola2) || string.IsNullOrWhiteSpace(parola3) || string.IsNullOrWhiteSpace(parola4) || string.IsNullOrWhiteSpace(parola5) || string.IsNullOrWhiteSpace(parola6) || string.IsNullOrWhiteSpace(parola7))
            {
                Console.WriteLine("Assicurati che tutti i campi siano riempiti");
                return;
            }

            bool isTfemmValid = float.TryParse(parola3, out float t_femm);
            bool isTmascValid = float.TryParse(parola4, out float t_masc);
            bool isTbothValid = float.TryParse(parola5, out float t_both);
            bool isValRandValid = int.TryParse(parola6, out int val_rand);
            bool isLogicoValid = bool.TryParse(parola7, out bool logico);


            if (isTfemmValid && isTmascValid && isTbothValid && isValRandValid && isLogicoValid)
            {
                if (logico == false)
                    logicoString = "false";
                else
                    logicoString = "true";

                string regione = parola2;
                ElaborazioneCSV.Azione5(anno, regione, t_femm, t_masc, t_both, val_rand, logicoString);
                Console.WriteLine("Azione eseguita correttamente");
            }
            else
            {
                Console.WriteLine("Assicurati che tutti i dati in input siano nel formato corretto");
            }
        }

        private static void Azione9()
        {
            Console.WriteLine("Inserisci la riga");
            string riga = Console.ReadLine();
            int successo = ElaborazioneCSV.Azione9(riga);
           
            if (successo == 1)
            {
                Console.WriteLine("La tua ricerca è stata individuata e cancellata");
            }
            else if (successo == -1)
            {
                Console.WriteLine("La tua ricerca non ha avuto risultati");
            }
            else
            {
                Console.WriteLine("Errore");
            }
        }
    }
}
