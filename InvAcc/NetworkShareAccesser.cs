using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
namespace InvAcc
{
    public class NetworkShareAccesser : IDisposable
    {
        [StructLayout(LayoutKind.Sequential)]
        private class NETRESOURCE
        {
            public int dwScope = 0;
            public int dwType = 0;
            public int dwDisplayType = 0;
            public int dwUsage = 0;
            public string lpLocalName = "";
            public string lpRemoteName = "";
            public string lpComment = "";
            public string lpProvider = "";
        }
        private const int RESOURCE_CONNECTED = 1;
        private const int RESOURCE_GLOBALNET = 2;
        private const int RESOURCE_REMEMBERED = 3;
        private const int RESOURCETYPE_ANY = 0;
        private const int RESOURCETYPE_DISK = 1;
        private const int RESOURCETYPE_PRINT = 2;
        private const int RESOURCEDISPLAYTYPE_GENERIC = 0;
        private const int RESOURCEDISPLAYTYPE_DOMAIN = 1;
        private const int RESOURCEDISPLAYTYPE_SERVER = 2;
        private const int RESOURCEDISPLAYTYPE_SHARE = 3;
        private const int RESOURCEDISPLAYTYPE_FILE = 4;
        private const int RESOURCEDISPLAYTYPE_GROUP = 5;
        private const int RESOURCEUSAGE_CONNECTABLE = 1;
        private const int RESOURCEUSAGE_CONTAINER = 2;
        private const int CONNECT_INTERACTIVE = 8;
        private const int CONNECT_PROMPT = 16;
        private const int CONNECT_REDIRECT = 128;
        private const int CONNECT_UPDATE_PROFILE = 1;
        private const int CONNECT_COMMANDLINE = 2048;
        private const int CONNECT_CMD_SAVECRED = 4096;
        private const int CONNECT_LOCALDRIVE = 256;
        private const int NO_ERROR = 0;
        private const int ERROR_ACCESS_DENIED = 5;
        private const int ERROR_ALREADY_ASSIGNED = 85;
        private const int ERROR_BAD_DEVICE = 1200;
        private const int ERROR_BAD_NET_NAME = 67;
        private const int ERROR_BAD_PROVIDER = 1204;
        private const int ERROR_CANCELLED = 1223;
        private const int ERROR_EXTENDED_ERROR = 1208;
        private const int ERROR_INVALID_ADDRESS = 487;
        private const int ERROR_INVALID_PARAMETER = 87;
        private const int ERROR_INVALID_PASSWORD = 1216;
        private const int ERROR_MORE_DATA = 234;
        private const int ERROR_NO_MORE_ITEMS = 259;
        private const int ERROR_NO_NET_OR_BAD_PATH = 1203;
        private const int ERROR_NO_NETWORK = 1222;
        private const int ERROR_BAD_PROFILE = 1206;
        private const int ERROR_CANNOT_OPEN_PROFILE = 1205;
        private const int ERROR_DEVICE_IN_USE = 2404;
        private const int ERROR_NOT_CONNECTED = 2250;
        private const int ERROR_OPEN_FILES = 2401;
        private string _remoteUncName;
        private string _remoteComputerName;
        public string RemoteComputerName
        {
            get
            {
                return _remoteComputerName;
            }
            set
            {
                _remoteComputerName = value;
                _remoteUncName = "\\" + _remoteComputerName;
            }
        }
        public string UserName
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        [DllImport("Mpr.dll")]
        private static extern int WNetUseConnection(IntPtr hwndOwner, NETRESOURCE lpNetResource, string lpPassword, string lpUserID, int dwFlags, string lpAccessName, string lpBufferSize, string lpResult);
        [DllImport("Mpr.dll")]
        private static extern int WNetCancelConnection2(string lpName, int dwFlags, bool fForce);
        public static NetworkShareAccesser Access(string remoteComputerName)
        {
            return new NetworkShareAccesser(remoteComputerName);
        }
        public static NetworkShareAccesser Access(string remoteComputerName, string domainOrComuterName, string userName, string password)
        {
            return new NetworkShareAccesser(remoteComputerName, domainOrComuterName + "\\" + userName, password);
        }
        public static NetworkShareAccesser Access(string remoteComputerName, string userName, string password)
        {
            return new NetworkShareAccesser(remoteComputerName, userName, password);
        }
        private NetworkShareAccesser(string remoteComputerName)
        {
            RemoteComputerName = remoteComputerName;
            ConnectToShare(_remoteUncName, null, null, promptUser: true);
        }
        private NetworkShareAccesser(string remoteComputerName, string userName, string password)
        {
            RemoteComputerName = remoteComputerName;
            UserName = userName;
            Password = password;
            ConnectToShare(_remoteUncName, UserName, Password, promptUser: false);
        }
        private void ConnectToShare(string remoteUnc, string username, string password, bool promptUser)
        {
            NETRESOURCE nETRESOURCE = new NETRESOURCE();
            nETRESOURCE.dwType = 1;
            nETRESOURCE.lpRemoteName = remoteUnc;
            NETRESOURCE nr = nETRESOURCE;
            if (((!promptUser) ? WNetUseConnection(IntPtr.Zero, nr, password, username, 0, null, null, null) : WNetUseConnection(IntPtr.Zero, nr, "", "", 24, null, null, null)) == 0)
            {
            }
        }
        private void DisconnectFromShare(string remoteUnc)
        {
            int result = WNetCancelConnection2(remoteUnc, 1, fForce: false);
            if (result != 0)
            {
                throw new Win32Exception(result);
            }
        }
        public void Dispose()
        {
            try
            {
                DisconnectFromShare(_remoteUncName);
            }
            catch
            {
            }
        }
    }
}
