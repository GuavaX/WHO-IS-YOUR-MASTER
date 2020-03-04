using UnityEngine;

public static class SelectRole 
{    
    public static bool selectOver = false;

    private static string role = "tiger"; //所選角色預設為老虎
     

    /// <summary>
    /// 設定所選角色
    /// </summary>
    public static void SetRole(string roleName)
    {
        if (roleName == "tiger"|| roleName == "father" || roleName == "monster")
        {
            role = roleName;           
        }
        
    }

    /// <summary>
    /// 得到所選角色
    /// </summary>
    public static string GetRole()
    {
        return role;
    }
    
}
