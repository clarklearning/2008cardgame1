using DiyCollection16;
using MyWork;
using Running;

class Test{
    public static void ForExcel2HTML(){
            string thispath = System.Environment.CurrentDirectory;
            Console.WriteLine(thispath + "/MyWork/data.xlsx");
            var db = Excel2HTML.Excel2Table(thispath + "/MyWork/data.xlsx", CompareFlag.Compare);
        }

    public static void ForEvent(){
        Customer customer = new Customer();
        Waiter waiter = new Waiter();
        customer.Order += waiter.Action;
        customer.Action();
        customer.PayTheBill();
    }

    public static void ForDict(){
        Dictionary<string, ConsoleColor> debugColorMap = new Dictionary<string, ConsoleColor>(){
            ["debug"] = ConsoleColor.Yellow,
            ["error"] = ConsoleColor.Red,
            ["warning"] = ConsoleColor.Yellow
        };
        debugColorMap["debug"] = ConsoleColor.Cyan;
        foreach(var kp in debugColorMap){
            Console.BackgroundColor = kp.Value;
            Console.WriteLine(kp.Key);
        }
    }


    public static void ForDictEquality(){
        var dictEqual = new Dictionary<string, string>(new StringNumberEquality()){
            ["1"] = "1",
            ["2"] = "2"
        };
        dictEqual.Add("22", "22");
        foreach(var dic in dictEqual){
            Console.WriteLine(dic.Key+" "+dic.Value);
        }
    }

    public static void ForList(){
            string a = "杀";
            string b = "借刀杀人m";
            string c = "ab";
            List<string> cardList = new List<string>(){a,b, c};
            //cardList.Sort(new StringNumberComparison().Compare);
            foreach(var card in cardList){
                Console.WriteLine(card);
            }
            int search = cardList.BinarySearch("借钱");
            if(search < 0){
                Console.WriteLine(search);
            }
    }

    
    public static void ForEnumerable(){
        var csBuiltIn = new CSBuiltInTypes();
        foreach(var builtin in csBuiltIn){
            Console.WriteLine(builtin);
        }
    }
}