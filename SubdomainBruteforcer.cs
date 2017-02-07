using System;
using System.Net;
using System.IO;

class SubdomainBruteforcer{
public static void Main(String[] ar){
	
	String domain,wordListFileName;
	char choice='Y';
	Console.WindowWidth=130;

Console.WriteLine(@"  ______       _         _                   _          ______                             ___                             ");
Console.WriteLine(@" / _____)     | |       | |                 (_)        (____  \               _           / __)                            ");
Console.WriteLine(@"( (____  _   _| |__   __| | ___  ____  _____ _ ____     ____)  ) ____ _   _ _| |_ _____ _| |__ ___   ____ ____ _____  ____ ");
Console.WriteLine(@" \____ \| | | |  _ \ / _  |/ _ \|    \(____ | |  _ \   |  __  ( / ___) | | (_   _) ___ (_   __) _ \ / ___) ___) ___ |/ ___)");
Console.WriteLine(@" _____) ) |_| | |_) | (_| | |_| | | | / ___ | | | | |  | |__)  ) |   | |_| | | |_| ____| | | | |_| | |  ( (___| ____| |    ");
Console.WriteLine(@"(______/|____/|____/ \____|\___/|_|_|_\_____|_|_| |_|  |______/|_|   |____/   \__)_____) |_|  \___/|_|   \____)_____)_|    ");
Console.WriteLine(@"                                                                                        Amit Kumar- linkedin.com/in/Hitman ");

Console.WriteLine("\n\n");
//Console.Read();

Console.Write("\nDomain: ");
domain=Console.ReadLine();

Console.Write("\nWordlist(.txt): ");
wordListFileName=Console.ReadLine();

//Console.WriteLine("\nOutput File(.txt): ");
//Console.Read();

Console.Write("\nLaunch/Cancel(Y/C): ");
   choice=(char)Console.Read();
    if(choice=='C'||choice=='c')
	{Console.WriteLine("Cancelled");
     Environment.Exit(0);
	 }

	 Console.WriteLine("\n*************\n");
	 
var wordList=File.ReadAllLines(@"C:\Users\1337\Documents\SubdomainBruteforcer\"+wordListFileName);

foreach(var subdomain in wordList){
	
     Console.Write(" : http://"+subdomain+"."+domain);

     HttpWebResponse response = null;

        try
        {   
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://"+subdomain+"."+domain);
            request.Method = "GET";

            response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());
            //Console.Write(sr.ReadToEnd());
			
			
			if((int)response.StatusCode==200){
				Console.Write("\r✓");
				Console.WriteLine("\r");
			
			using(StreamWriter writeDomain=File.AppendText("WorkingSubdomains.txt")){
				writeDomain.WriteLine("http://"+subdomain+"."+domain);
			}
			
			//StreamWriter(@"C:\Users\1337\Documents\SubdomainBruteforcer\WorkingSubdomains.txt",false);
			
			//writeDomain.Close();
			}
			
		//	Console.Write("Code:"+(int)response.StatusCode);
        }
        catch (WebException e)
        {
            if (e.Status == WebExceptionStatus.ProtocolError)
            {
                response = (HttpWebResponse)e.Response;
             //   Console.WriteLine("Errorcode: {0}", (int)response.StatusCode);
			 Console.Write("\rX");
		          Console.WriteLine("\r");
				
            }
            else
            {     Console.Write("\rX");
		          Console.WriteLine("\r");
              //  Console.WriteLine("Error: {0}", e.Status);
				
            }
			
		//	Console.Read();
        }
        finally
        {
            if (response != null)
            {
                response.Close();
				
            }
        }

     }
Console.WriteLine("Done");
Console.Read();
        }
   }
 