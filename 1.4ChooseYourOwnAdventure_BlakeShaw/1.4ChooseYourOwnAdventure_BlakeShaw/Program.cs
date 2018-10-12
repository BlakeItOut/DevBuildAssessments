using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4ChooseYourOwnAdventure_BlakeShaw
{
    class Program
    {
        static void Main(string[] args)
        {
            char response1;
            char response2;
            char response3;
            char response4;
            char response5;
            char startOver;
            string startingCharacter = @"                     ______
                   <((((((\\\
                   /      . }\
                   ;--..--._|}
(\                 '--/\--'  )
 \\                | '-'  :'|
  \\               . -==- .-|
   \\               \.__.'   \--._
   [\\          __.--|       //  _/'--.
   \ \\       .'-._ ('-----'/ __/      \
    \ \\     /   __>|      | '--.       |
     \ \\   |   \   |     /    /       /
      \ '\ /     \  |     |  _/       /
       \  \       \ |     | /        /
        \  \      \        /";
            string firstBeast = @"                                             ,--,  ,.-.
               ,                   \,       '-,-`,'-.' | ._
              /|           \    ,   |\         }  )/  / `-,',
              [ ,          |\  /|   | |        /  \|  |/`  ,`
              | |       ,.`  `,` `, | |  _,...(   (      .',
              \  \  __ ,-` `  ,  , `/ |,'      Y     (   /_L\
               \  \_\,``,   ` , ,  /  |         )         _,/
                \  '  `  ,_ _`_,-,<._.<        /         /
                 ', `>.,`  `  `   ,., |_      |         /
                   \/`  `,   `   ,`  | /__,.-`    _,   `\
               -,-..\  _  \  `  /  ,  / `._) _,-\`       \
                \_,,.) /\    ` /  / ) (-,, ``    ,        |
               ,` )  | \_\       '-`  |  `(               \
              /  /```(   , --, ,' \   |`<`    ,            |
             /  /_,--`\   <\  V /> ,` )<_/)  | \      _____)
       ,-, ,`   `   (_,\ \    |   /) / __/  /   `----`
      (-, \           ) \ ('_.-._)/ /,`    /
      | /  `          `/ \\ V   V, /`     /
   ,--\(        ,     <_/`\\     ||      /
  (   ,``-     \/|         \-A.A-`|     /
 ,>,_ )_,..(    )\          -,,_-`  _--`
(_ \|`   _,/_  /  \_            ,--`
 \( `   <.,../`     `-.._   _,-`";
            string secondBeast = @"                _ ___                /^^\ /^\  /^^\_
    _          _@)@) \            ,,/ '` ~ `'~~ ', `\.
  _/o\_ _ _ _/~`.`...'~\        ./~~..,'`','',.,' '  ~:
 / `,'.~,~.~  .   , . , ~|,   ,/ .,' , ,. .. ,,.   `,  ~\_
( ' _' _ '_` _  '  .    , `\_/ .' ..' '  `  `   `..  `,   \_
 ~V~ V~ V~ V~ ~\ `   ' .  '    , ' .,.,''`.,.''`.,.``. ',   \_
  _/\ /\ /\ /\_/, . ' ,   `_/~\_ .' .,. ,, , _/~\_ `. `. '.,  \_
 < ~ ~ '~`'~'`, .,  .   `_: ::: \_ '      `_/ ::: \_ `.,' . ',  \_
  \ ' `_  '`_    _    ',/ _::_::_ \ _    _/ _::_::_ \   `.,'.,`., \-,-,-,_,_,
   `'~~ `'~~ `'~~ `'~~  \(_)(_)(_)/  `~~' \(_)(_)(_)/ ~'`\_.._,._,'_;_;_;_;_;";
            string grimReaper = @"             ___          
            /   \\        
       /\\ | . . \\       
     ////\\|     ||       
   ////   \\ ___//\       
  ///      \\      \      
 ///       |\\      |     
//         | \\  \   \    
/          |  \\  \   \   
           |   \\ /   /   
           |    \/   /    
           |     \\/|     
           |      \\|     
           |       \\     
           |        |     
           |_________\";
            string theStruggle = @"                                      /|
                                     |\|
                                     |||
                                     |||
                                     |||
                                     |||
                                     |||
                                     |||
                                  ~-[{o}]-~
                                     |/|
                                     |/|
             ///~`     |\\_          `0'         =\\\\         . .
            ,  |='  ,))\_| ~-_                    _)  \      _/_/|
           / ,' ,;((((((    ~ \                  `~~~\-~-_ /~ (_/\
         /' -~/~)))))))'\_   _/'                      \_  /'  D   |
        (       (((((( ~-/ ~-/                          ~-;  /    \--_
         ~~--|   ))''    ')  `                            `~~\_    \   )
             :        (_  ~\           ,                    /~~-     ./
              \        \_   )--__  /(_/)                   |    )    )|
    ___       |_     \__/~-__    ~~   ,'      /,_;,   __--(   _/      |
  //~~\`\    /' ~~~----|     ~~~~~~~~'        \-  ((~~    __-~        |
((()   `\`\_(_     _-~~-\                      ``~~ ~~~~~~   \_      /
 )))     ~----'   /      \                                   )       )
  (         ;`~--'        :                                _-    ,;;(
            |    `\       |                             _-~    ,;;;;)
            |    /'`\     ;                          _-~          _/
           /~   /    |    )                         /;;;''  ,;;:-~
          |    /     / | /                         |;;'   ,''
          /   /     |  \\|                         |   ,;(              
        _/  /'       \  \_)                   .---__\_    \,--._______
       ( )|'         (~-_|                   (;;'  ;;;~~~/' `;;|  `;;;\
        ) `\_         |-_;;--__               ~~~----__/'    /'_______/
        `----'       (   `~--_ ~~~;;------------~~~~~ ;;;'_/'
                     `~~~~~~~~'~~~-----....___;;;____---~~";
            string triumph = @"   __     __
  |  \   /  |
  ||| \_/ |||
  |||||||||||
  |||||||||||
  |||||||||||
__|||||||||||__
\ \--.|||.--/ /
 \ \__\_/__/ /
  \ TRIUMPH /
   ---------";
            string fireworks = @"                                   .''.       
       .''.      .        *''*    :_\/_:     . 
      :_\/_:   _\(/_  .:.*_\/_*   : /\ :  .'.:.'.
  .''.: /\ :   ./)\   ':'* /\ * :  '..'.  -=:o:=-
 :_\/_:'.:::.    ' *''*    * '.\'/.' _\(/_'.':'.'
 : /\ : :::::     *_\/_*     -= o =-  /)\    '  *
  '..'  ':::'     * /\ *     .'/.\'.   '
      *            *..*         :";
            string practice = @"           __________                                 
         .'----------`.                              
         | .--------. |                             
         | |########| |       __________              
         | |########| |      /__________\             
.--------| `--------' |------|    --=-- |-------------.
|        `----,-.-----'      |o ======  |             | 
|       ______|_|_______     |__________|             | 
|      /  %%%%%%%%%%%%  \                             | 
|     /  %%%%%%%%%%%%%%  \                            | 
|     ^^^^^^^^^^^^^^^^^^^^                            | 
+-----------------------------------------------------+
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^";
            while (true)
            {
                Console.WriteLine("It is time for your Developer Hero's Journey!");
                while (true)
                {
                    Console.WriteLine(startingCharacter);
                    response1 = getUserInput("Will you go on this journey with me? (y/n) ");
                    if (response1 == 'y')
                    {
                        Console.WriteLine(firstBeast);
                        response2 = getUserInput("Are you prepared to face Dev.Build beast? (y/n) ");
                        if (response2 == 'y')
                        {
                            Console.WriteLine(secondBeast);
                            response3 = getUserInput("The Dev.Build beast asks you, \"Are you done with learning yet?\" (y/n) ");
                            if (response3 == 'n')
                            {
                                goto Learned;
                            } else
                            {
                                Console.WriteLine("Go back and see what more you can learn perhaps.");
                                break;
                            }
                        } else
                        {
                            Console.WriteLine(practice);
                            response3 = getUserInput("What would you like to do to prepare? (g=give me the answers, p=practice) ", 'g', 'p');
                            if (response3 == 'p')
                            {
                                goto Learned;
                            } else
                            {
                                Console.WriteLine(grimReaper);
                                Console.WriteLine("With all the answers, nothing left to learn? Think again. Everything left to learn.");
                                break;
                            }
                        }
                    } else
                    {
                        Console.WriteLine(grimReaper);
                        Console.WriteLine("You are not ready. Try again perhaps.");
                        break;
                    }
                    Learned:
                    Console.WriteLine(theStruggle);
                    Console.WriteLine("You have indeed learned to love the process but your code still fails!");
                    response4 = getUserInput("Would you like to use the debugger? (y/n) ");
                    if (response4 == 'y')
                    {
                        Console.WriteLine(triumph);
                        Console.WriteLine("Great Scott! You have transformed your code!");
                        response5 = getUserInput("The Dev.Build beast is defeated! What do you do now? (s=stop challenging yourself so much, f=find the next challenge) ", 's', 'f');
                        if (response5 == 'f')
                        {
                            Console.WriteLine(fireworks);
                            Console.WriteLine("You've done it, completed the hero's journey full cycle and now you can come back for more.");
                        } else
                        {
                            Console.WriteLine(grimReaper);
                            Console.WriteLine("So close to completing the cycle. Why stop now? Perhaps next time.");
                        }
                        break;
                    } else
                    {
                        Console.WriteLine(grimReaper);
                        Console.WriteLine("There is still more for you to learn.");
                        break;
                    }
                }
                startOver = getUserInput("Would you like to start over? (y/n) ");
                if (startOver == 'y')
                {
                    continue;
                } else
                {
                    break;
                }
            }   
        }

        static char getUserInput(string prompt, char validInput1 = 'y', char validInput2 = 'n')
        {
            while (true)
            {
                Console.Write(prompt);
                char response = Char.ToLower(Console.ReadKey().KeyChar);
                if (response != validInput1 && response != validInput2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("This response is invalid. Please enter another.");
                    continue;
                } else
                {
                    Console.WriteLine("");
                    return response;
                }
            }
        }
    }
}
