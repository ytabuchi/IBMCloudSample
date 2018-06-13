using System;
namespace IBMCloud.NetStandardCore
{
    public static class Secrets
    {
        public static readonly string UserName = "bb657369-cd26-436a-b73a-594c0596362a"; // Watsonのユーザー名
        public static readonly string Password = "IUkkOpwQVMR5"; // Watsonのパスワード
        public static readonly string WorkspaceId = "b8dda69d-b4b9-480b-90fe-96a8002c99a8"; //呼び出すWorkspaceID
        public static readonly string VersionDate = "2017-10-13"; //VersionDate()
        public static readonly Uri NodeRedUrl = new Uri("https://xm-node-red-sample.mybluemix.net/");
    }
}
