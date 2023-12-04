using System.Collections.Concurrent;

namespace ClassLibraryStores
{
    public class Stores
    {
        public static List<Stores> ListOfStores { get; set; } = new List<Stores>();

        public enum STATUS { FATAL = 0, OK = 1, WARNING = 2 };
        public enum CODE_OF_STORE
        {
            STORE_01, STORE_02, STORE_03, STORE_04, STORE_05, STORE_06, STORE_07, STORE_08, STORE_09, STORE_10, STORE_11, STORE_12, STORE_13,
            STORE_14, STORE_15, STORE_16, STORE_18, STORE_19, STORE_20, STORE_21, STORE_22, STORE_23, STORE_24, STORE_25, STORE_26, STORE_27, STORE_28,
            STORE_30, STORE_31, STORE_32, STORE_33, STORE_34, STORE_35, STORE_36, STORE_37, STORE_38, STORE_39, STORE_40, STORE_41, STORE_42, 
            STORE_43, STORE_44, STORE_45, STORE_46, STORE_47, STORE_48, STORE_50, STORE_51, STORE_52, STORE_53, STORE_54, STORE_55, STORE_56, 
            STORE_57, STORE_58, STORE_59, STORE_60, STORE_61, STORE_62, STORE_63, STORE_64, STORE_65, STORE_66, STORE_67, STORE_68,
            STORE_72, STORE_73, STORE_75, STORE_78, STORE_80, STORE_81, STORE_90, STORE_210
        };

        public CODE_OF_STORE CodeStore { get; set; }
        public STATUS Status { get; set; }
        public string CodeOfStatus { get; set; }
        public string Message { get; set; }
        public bool Updated { get; set; }
        public bool AlreadySong { get; set; }

        public Stores()
        {

        }

        public Stores(CODE_OF_STORE codeStore, STATUS status, string codeOfStatus, string message, bool updated, bool alreadySong)
        {
            CodeStore = codeStore;
            Status = status;
            CodeOfStatus = codeOfStatus;
            Message = message;
            Updated = updated;
            AlreadySong = alreadySong;  
        }
    }
}