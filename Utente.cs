namespace esercitazione;

public class Utente
{
    private static string? username;
    private static bool isAuthenticated = false;
    private static DateTime loginTime;
    private static List<DateTime> accessi = new List<DateTime>();

    public static bool Login(string user, string password, string confirmPassword)
    {
        if(!string.IsNullOrEmpty(user) && password == confirmPassword)
        {
            username = user;
            isAuthenticated = true;
            loginTime = DateTime.Now;
            accessi.Add(loginTime);
            return true;
        }
        return false;
    }

    public static bool Logout()
    {
        if(isAuthenticated)
        {
            isAuthenticated = false;
            return true;
        }
        return false;
    }

    public static DateTime? GetLoginTime()
    {
        if(isAuthenticated)
        {
            return loginTime;
        }
        return null;
    }

    public static List<DateTime> GetAccessHistory()
    {
        return accessi;
    }
}
