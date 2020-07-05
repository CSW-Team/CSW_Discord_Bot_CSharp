using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace DiscordBot_Test
{
    class Program
    {
        private readonly DiscordSocketClient _client;
        static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }
        public Program()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;
            _client.Ready += Ready;
            _client.MessageReceived += MessageReceivedAsync;
        }
        public async Task MainAsync()
        {
            await _client.LoginAsync(TokenType.Bot, "your_token");
            await _client.StartAsync();
            await Task.Delay(-1);
        }
        private Task Log(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }
        private Task Ready()
        {
            Console.WriteLine($"{_client.CurrentUser} 연결됨!");
            return Task.CompletedTask;
        }
        private async Task help(SocketMessage message)
        {
            await message.Channel.SendMessageAsync("```평범한(?) 디스코드 봇입니다. Made by Unnamedinventor\n개발자 블로그 : doso5.p-e.kr" +
                "\n단순히 재미를 위해 만들어졌으며, 평범한 디스코드가 필요합니다." +
                "\n테스트용 기능을 보려면 '?' 식별자를, 언어별 Hello world 구문을 보려고 한다면 '$'식별자를 사용해 주세요." +
                //"\n일정 관리 기능을 사용하려면 '//'식별자를 사용해 주세요." +
                //"\n도배 등의 다중 삭제 기능을 사용하려면 '%' 식별자 옆에 없앨 개수를 넣어 주세요." +
                "\n해당 화면이 다시 보고 싶으시다면, 봇에게 '?help'라고 해주세요.```");
            await message.Channel.SendMessageAsync("조물주는 당신처럼 나에 대해 물어보는 사람에게 이 쪽지를 건네랬어. 거기엔 뭐라고 적혀 있어?");
        }
        private async Task MessageReceivedAsync(SocketMessage message)
        {
            Random r = new Random();
            if (message.Author.Id == _client.CurrentUser.Id) return;
            if (message.Content[0] == '?')
            {
                if (message.Content == "?help") await help(message);
                else if (message.Content == "?ping") await message.Channel.SendMessageAsync("pong!");
                else if (message.Content == "?pong") await message.Channel.SendMessageAsync("ping!");
                else if (message.Content == "?핑") await message.Channel.SendMessageAsync("퐁!");
                else if (message.Content == "?퐁") await message.Channel.SendMessageAsync("핑!");
                else if (message.Content == "?홍형엽") await message.Channel.SendMessageAsync("내 조물주의 이름을 어떻게 아는 거지...?");
                else if (message.Content == "?이홍규" || message.Content == "?이찬우" || message.Content == "?민웅기") await message.Channel.SendMessageAsync("동쪽 지역의 계란은 맛있다던데.");
                else if (message.Content == "?ㅎㅇ" || message.Content == "?안녕" || message.Content == "?반가워") await message.Channel.SendMessageAsync("하이하이!");
                else if (message.Content == "?ㅂㅂ" || message.Content == "?잘있어" || message.Content == "?바이바이") await message.Channel.SendMessageAsync("바이바이!");
                else if (message.Content == "?일정기능") await message.Channel.SendMessageAsync("알림을 보내주는 기능이야!" +
                    "\n'//' 구분자를 사용하여 쓸 수 있어!" +
                    "\n작성 양식 : 년도 월 일 시 분 일정 이름");
                else if (message.Content == "?주사위")
                {
                    int a = r.Next(1, 7);
                    if (a == 1 || a == 3 || a == 6)
                    {
                        await message.Channel.SendMessageAsync("주사위를 던져서 " + a + "이 나왔어!");
                    }
                    else await message.Channel.SendMessageAsync("주사위를 던져서 " + a + "가 나왔어!");
                }
                else if (message.Content == "?가위")
                {
                    int a = r.Next(1, 4);
                    if (a == 1) await message.Channel.SendMessageAsync("바위:punch:! 내가 이겼다!");
                    else if (a == 2) await message.Channel.SendMessageAsync("가위:v:! 비겼어!");
                    else if (a == 3) await message.Channel.SendMessageAsync("보:raised_hand:! 내가 졌네....");
                }
                else if (message.Content == "?바위")
                {
                    int a = r.Next(1, 4);
                    if (a == 1) await message.Channel.SendMessageAsync("바위:punch:! 비겼어!");
                    else if (a == 2) await message.Channel.SendMessageAsync("가위:v:! 내가 졌네....");
                    else if (a == 3) await message.Channel.SendMessageAsync("보:raised_hand:! 내가 이겼다!");
                }
                else if (message.Content == "?보")
                {
                    int a = r.Next(1, 4);
                    if (a == 1) await message.Channel.SendMessageAsync("바위:punch:! 내가 졌네....");
                    else if (a == 2) await message.Channel.SendMessageAsync("가위:v:! 내가 이겼다!");
                    else if (a == 3) await message.Channel.SendMessageAsync("보raised_hand:! 비겼어!");
                }
                else if (message.Content == "?시간") await message.Channel.SendMessageAsync("현재 시간은 " + DateTime.Now.ToString("HH") + "시 " + DateTime.Now.ToString("mm") + "분!");
                else if (message.Content == "?날짜")
                {
                    DateTime dt = new DateTime();
                    await message.Channel.SendMessageAsync("오늘은 20" + DateTime.Now.ToString("yy") + "년 " + DateTime.Now.ToString("MM") + "월 " + DateTime.Now.ToString("dd") + "일!");
                    switch (DateTime.Now.DayOfWeek.ToString())
                    {
                        case "Monday":
                            await message.Channel.SendMessageAsync("월요일이야!");
                            break;
                        case "Tuesday":
                            await message.Channel.SendMessageAsync("화요일이야!");
                            break;
                        case "Wednesday":
                            await message.Channel.SendMessageAsync("수요일이야!");
                            break;
                        case "Thursday":
                            await message.Channel.SendMessageAsync("목요일이야!");
                            break;
                        case "Friday":
                            await message.Channel.SendMessageAsync("금요일이야!");
                            break;
                        case "Saturday":
                            await message.Channel.SendMessageAsync("토요일이야!");
                            break;
                        case "Sunday":
                            await message.Channel.SendMessageAsync("일요일이야!");
                            break;
                        default:
                            await message.Channel.SendMessageAsync(dt.DayOfWeek.ToString());
                            break;
                    }

                }
                else await message.Channel.SendMessageAsync("지원하지 않는 명령어이거나, 삭제된 것 같아!");
            }
            else if (message.Content[0] == '$')
            {
                if (message.Content == "$C" || message.Content == "$c") await message.Channel.SendMessageAsync("```#include <stdio.h>" +
                     "\n\nint main()\n{\n    printf(\"Hello World!\");\n    return 0;\n}```");
                else if (message.Content == "$C++" || message.Content == "$c++") await message.Channel.SendMessageAsync("```#include <iostream>" +
                      "\n\nusing namespace std;\n\nint main()\n{\n    cout << \"Hello World!\";\n    return 0;\n}```");
                else if (message.Content == "$Chef" || message.Content == "$chef") await message.Channel.SendMessageAsync("```" +
                     "Hello World Cake with Chocolate sauce.\n\n" +
                     "This prints hello world. while being tastier than Hello World Souffle. The main chef makes a \"world!\" cake, which he puts in the baking dish. When he gets the sous chef to make the \"Hello\" chocolate sauce, it gets put into the baking dish and then the whole thing is printed when he refrigerates the sauce. When actually cooking, i\'m interpreting the chocolate sauce baking dish to be seperate from the cake one and Liquify to mean either melt or blend depending on context.\n\n" +
                     "Ingredients.\n33 g chocolate chips\n100 g butter\n54 ml double cream\n2 piches baking powder\n114 g sugar\n111 ml beaten eggs\n119 g flour\n32 g cocoa powder\n0 g cake mixture\n\n" +
                     "Cooking time : 25 minutes.\n\nPre-heat oven to 180 degrees Celcius.\n\n" +
                     "Method.\nPut chocolate chips into the mixing bowl.\nPut butter into the mixing bowl.\n" +
                     "Put sugar into the mixing bowl.\nPut beaten eggs into the mixing bowl.\n" +
                     "Put flour into the mixing bowl.\nPut baking powder into the mixing bowl.\n" +
                     "Put cocoa powder into the mixing bowl.\nStir the mixing bowl for 4 minutes.\n" +
                     "Combine double cream into the mixing bowl.\nPour contents of the mixing bowl into the baking dish.\n" +
                     "bake the cake mixture.\nWait until baked.\nServe with chocolate sauce.\n" +
                     "\nchocolate sauce.\n\nIngredients.\n111 g sugar\n108 ml hot water\n108 ml heated double cream\n" +
                     "101 g dark chocolate\n72 g milk chocolate\n\nMethod.\nClean the mixing bowl.\nPut sugar into the mixing bowl.\nPut hot water into the mixing bowl.\n" +
                     "Put heated double cream into the mixing bowl.\ndissolve the sugar.\nagitate the sugar until dissolved.\nLiquify the dark chocolate.\nPut dark chocolate into the mixing bowl.\n" +
                     "Liquify the milk chocolate.\nPut milk chocolate into the mixing bowl.\nLiquify contents of the mixing bowl.\nPour contents of the mixing bowl into the baking dish.\nRefrigerate for 1 hour.```");
                else if (message.Content == "$lolcode" || message.Content == "$LOLCODE") await message.Channel.SendMessageAsync("```HAI\nCAN HAS STDIO?\nVISIBLE \"HAI WORLD!\"\nKTHXBYE```");
                else if (message.Content == "$JAVA" || message.Content == "$Java" || message.Content == "$java") await message.Channel.SendMessageAsync("```class HelloWorldApp {\n    public static void main(String[] args) {\n        System.out.println(\"Hello World!\");\n    }\n}```");
                else if (message.Content == "$BrainFuck") await message.Channel.SendMessageAsync("``` ++++++++++\n[>+++++++>++++++++++>+++>+<<<<-]\n>++.>+.+++++++..+++.>++++++++++++++.------------.<<+++++++++++++++.>.+++.------.--------.>+.```");
                else if (message.Content == "$C#" || message.Content == "$c#") await message.Channel.SendMessageAsync("```using system;\n\nnamespace HelloWorld\n{\n    " +
                     "class Program\n    {\n        static void Main(string[] args)\n        {\n            Console.WriteLine(\"Hello World!\");\n        }\n    }\n}```");
                else if (message.Content == "$Python3") await message.Channel.SendMessageAsync("```print(\"Hello, world!\")```");
                else if (message.Content == "$Python2") await message.Channel.SendMessageAsync("```import stdio\nstdio.writeln('Hello, World')```");
                else if (message.Content == "$D" || message.Content == "$d") await message.Channel.SendMessageAsync("```import std.stdio;\n\nvoid main()\n{\n    " +
                    "writeln(\"Hello World!\");\n}```");
                else if (message.Content == "$Dart" || message.Content == "$DART" || message.Content == "$dart") await message.Channel.SendMessageAsync("```" +
                     "main()\n{\n    print('Hello World!');\n}```");
                else if (message.Content == "$FiM++") await message.Channel.SendMessageAsync("```" +
                     "Dear Princess Celestia: Letter About Equestria.\n\nToday I learned:\n\nI wrote \"Hello World!\".\n\nYour faithful student, Twilight Sparkle.```");
                //else if (message.Content == "$Ruby" || message.Content == "$ruby" || message.Content == "$RUBY") await message.Channel.SendMessageAsync("```def f():\n    print ('Hello World!')\n\nf()```");
                else if (message.Content == "$Go" || message.Content == "$GO" || message.Content == "$go") await message.Channel.SendMessageAsync("```" +
                         "package main\n\nimport \"fmt\"\n\nfunc main() {\n    fmt.Println(\"Hello World!\")\n}```");
                else await message.Channel.SendMessageAsync("지원하지 않는 명령어이거나, 삭제된 것 같아!");
            }
            if (message.Content == "ㅤ") await message.Channel.SendMessageAsync("**삐빗**. 공백 문자 감지!");
            if (message.Content[0] == '/' && message.Content[1] == '/')
            {

            }
            /*if(message.Content[0] == '%')
            {
                //int a = int.Parse(message.Content + 1);
                //for (int i = 1; i <= a + 1; i++)
                //{
                    await message.Channel.DeleteMessageAsync(1);
                //}
            }*/
        }
    }
}