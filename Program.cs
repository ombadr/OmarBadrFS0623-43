using System.Runtime.CompilerServices;

namespace esercitazione;
class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("===============OPERAZIONI==============");
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Verifica cronologia accessi");
            Console.WriteLine("5.: Esci");
            Console.WriteLine("======================================");
            Console.Write("Scelta: ");

            int scelta;
            int.TryParse(Console.ReadLine(), out scelta);

            switch(scelta)
            {
                case 1:
                    EseguiLogin();
                    break;
                case 2:
                    EseguiLogout();
                    break;
                case 3:
                    VerificaLogin();
                    break;
                case 4:
                    MostraAccessi();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }

        }
    }

    static void EseguiLogin()
    {
        Console.Write("Inserisci username: ");
        string username = Console.ReadLine();
        Console.Write("Inserisci password: ");
        string password = Console.ReadLine();
        Console.Write("Conferma password: ");
        string confirmPassword = Console.ReadLine();

        if(Utente.Login(username, password, confirmPassword))
        {
            Console.WriteLine("Login effettuato con successo!");
        } else
        {
            Console.WriteLine("Errore nel login. Controlla i dati inseriti.");
        }
    }

    static void EseguiLogout()
    {
        if(Utente.Logout())
        {
            Console.WriteLine("Logout effettuato con successo!");
        }
        else
        {
            Console.WriteLine("Nessun utente loggato!");
        }
    }

    static void VerificaLogin()
    {
        DateTime? loginTime = Utente.GetLoginTime();
        if(loginTime != null)
        {
           Console.WriteLine($"Login effettuato il {loginTime.Value.ToShortDateString()} alle {loginTime.Value.ToShortTimeString()}");
        } else {
            Console.WriteLine("Nessun utente loggato!");
        }
    }

    static void MostraAccessi()
    {
        List<DateTime> accessi = Utente.GetAccessHistory();
        if(accessi.Count > 0)
        {
            Console.WriteLine("Lista degli accessi:");
            foreach(var accesso in accessi)
            {
                Console.WriteLine($"- {accesso.ToShortDateString()} alle {accesso.ToShortTimeString()}");
            }
        }
        else
        {
            Console.WriteLine("Nessun accesso effettuato!");
        }
    }
}