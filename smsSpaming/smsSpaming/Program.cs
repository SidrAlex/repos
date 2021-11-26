using System;
using System.IO;
using System.Net;
using System.Text;

namespace smsSpaming
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDate = DateTime.Now.Date;
            var encodingEndDay = new DateTime(2021, 11, 10).AddDays(180).Date;
            var daysLeft = (encodingEndDay - currentDate).Days < 0 ? 0 : (encodingEndDay - currentDate).Days;

            if ((int)currentDate.DayOfWeek == 5)
            {
                Console.WriteLine("");
                try
                {
                    string urlResponse = "https://sms.ru";
                    string API = "68B094CC-1E7A-9DEE-641F-48873766D2FD";
                    string nmbr = "79253047679";
                    //string sergey = "79175554196";
                    string valera = "79032724107";
                    //string my = "79295841841";
                    //string numbers = $"{nmbr},{sergey},{valera}";
                    //string numbers = $"{nmbr},{valera}";
                    //string numbers = $"{my},{nmbr}";
                    string numbers = $"{nmbr}";

                    string msg = daysLeft == 0 ?
                        "Dont forget invite Sidr to drink party!!! =)" :
                        "For end Sidr`s encoding left " + daysLeft + " days =(";
                    urlResponse = "https://sms.ru/sms/send?api_id=" + API + "&to=" + numbers + "&msg=" + msg + "&json=1";
                    //отправка HTTP-запроса
                    WebRequest request = WebRequest.Create(urlResponse);
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                string line = "";
                                while ((line = reader.ReadLine()) != null)
                                {
                                    Console.WriteLine(line);
                                }
                            }
                        }
                        response.Close();
                        Console.WriteLine("Request is completed.");
                        Console.ReadLine();
                    }
                }
                catch (WebException exHttp)
                {
                    Console.WriteLine("Error of HTTP-request:");
                    // пишем текст ошибки
                    Console.WriteLine(exHttp.ToString());
                    // получаем статус исключения
                    WebExceptionStatus status = exHttp.Status;

                    if (status == WebExceptionStatus.ProtocolError)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)exHttp.Response;
                        Console.WriteLine("Error status code: {0} - {1}", (int)httpResponse.StatusCode, httpResponse.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    // вывод прочих ошибок
                    Console.WriteLine("Unknown error:");
                    Console.WriteLine(e.ToString());
                }
            }
        }

        private static StringBuilder encodingToUtf8(string msg)
        {
            byte[] result = System.Text.Encoding.UTF8.GetBytes(msg);
            StringBuilder res = new StringBuilder();
            foreach (byte b in result)
            {
                res.Append(b.ToString());
            }

            return res;
        }
    }
}
