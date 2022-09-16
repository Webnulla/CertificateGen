using System;

namespace CertificateGen
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("~~ Центр генерации сертификатов ~~~\n");
                Console.WriteLine("1. Создать корневой сертификат");
                Console.WriteLine("2. Создать сертификат");
                Console.Write("Выберите подпрограмму (0 - завершение работы приложения): ");
                if (int.TryParse(Console.ReadLine(), out int no))
                {
                    switch (no)
                    {
                        case 0:
                            Console.WriteLine("Завершение работы приложения.");
                            Console.ReadKey();
                            return;
                        case 1:

                            CertificateConfiguration certificateConfiguration = new CertificateConfiguration
                            {
                                CertName = "Yggdrasil CA",
                                OutFolder = @"D:",
                                Password = "12345",
                                CertDuration = 30
                            };
                            CertificateGenerationProvider certificateGenerationProvider =
                                new CertificateGenerationProvider();
                            certificateGenerationProvider.GenerateRootCertificate(certificateConfiguration);
                            Console.WriteLine("Сертификат создан!");
                            break;
                        case 2:
                            int counter = 0;
                            CertificateExplorerProvider certificateExplorerProvider =
                                new CertificateExplorerProvider(true);
                            certificateExplorerProvider.LoadCertificates();
                            foreach (var certificate in certificateExplorerProvider.Certificates)
                            {
                                Console.WriteLine($"{counter++} >>> {certificate}");
                            }

                            Console.Write("Укажите номер корневого сертификата: ");
                            CertificateConfiguration addCertificateConfiguration = new CertificateConfiguration
                            {
                                RootCertificate = certificateExplorerProvider
                                    .Certificates[int.Parse(Console.ReadLine())].Certificate,
                                CertName = "Asgard Department",
                                OutFolder = @"D:",
                                Password = "12345",
                            };
                            CertificateGenerationProvider certificateGenerationProvider2 =
                                new CertificateGenerationProvider();
                            certificateGenerationProvider2.GenerateCertificate(addCertificateConfiguration);
                            Console.WriteLine("Сертификат создан!");
                            break;
                        default:
                            Console.WriteLine("Некорректный номер подпрограммы. Пожалуйста, повторите ввод.");
                            break;
                    }
                }
                else
                    Console.WriteLine("Некорректный номер подпрограммы. Пожалуйста, повторите ввод.");
            }
        }
    }
}