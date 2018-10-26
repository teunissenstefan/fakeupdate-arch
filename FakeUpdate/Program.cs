using System;
using System.Threading;
using System.Collections.Generic;

namespace FakeUpdate
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                FakeUpdate();
            }
        }

        public static void FakeUpdate()
        {
            List<string> packages = new List<string> { "acpi_call-1.1.0-168", "archboot-2018.06-3", "bash-completion-2.1.5", "coreutils-8.30-1", "elfutils-0.150-2",
            "fixesproto-5.0-2", "fontconfig-2.11.1-1", "fontsproto-2.1.3.1", "freetype2-2.5.3-2", "graphite-1:1.2.4-1", "harfbuzz-0.9.26-2", "inputproto-2.3-1",
            "kbproto-1.0.6-1", "libdrm-2.4.54-1", "libfontenc-1.1.2-1", "libice-1.0.8-2", "libpciaccess-0.13.2-2", "libsm-1.2.2-2", "linux-4.18.16.arch1-1", 
            "linux-firmware-20181018.d877533-1", "xorg-server-1.15.1-1", "xorg-server-utils-7.6-3", "xorg-xinit-1.3.3-3",
            "c-ares-1.15.0-1", "dconf-0.30.1-1", "firefox-63.0-1", "imagemagick-7.0.8.14-1",
            "iproute2-4.19.0-1", "libmagick-7.0.8.14-1", "libnm-1.14.4-1",
            "librsvg-2:2.44.8-1", "mono-5.16.0.179-1", "networkmanager-1.14.4-1",
            "python-3.7.1-1", "python-requests-2.20.0-1", "python-urllib3-1.24-1",
            "upower-0.99.9-1" };
            packages.Sort();
            Console.WriteLine("warning: bash-completion-2.1.5 is up to date -- reinstalling");
            Thread.Sleep(900);
            Console.WriteLine("resolving dependencies...");
            Thread.Sleep(500);
            Console.WriteLine("looking for inter-conflicts...");
            Console.WriteLine();
            Thread.Sleep(1500);
            Console.Write("Packages ("+packages.Count+"): ");
            foreach (string package in packages)
            {
                Console.Write(package+" ");
            }
            Console.WriteLine(System.Environment.NewLine);
            Console.WriteLine("Total Download Size: 25.44 MiB");
            Console.WriteLine("Total Installed Size: 99.30 MiB");
            Console.WriteLine();
            Console.WriteLine(":: Proceed with installation? [Y/n] y");
            Console.WriteLine(":: Retrieving packages...");
            Thread.Sleep(1000);
            foreach (string package in packages)
            {
                ProgressBarMsg(" "+package, 20);
            }
            ProgressBarMsg("(" + packages.Count + "/" + packages.Count + ") checking keys in keyring", 20);
            ProgressBarMsg("(" + packages.Count + "/" + packages.Count + ") checking package integrity", 20);
            ProgressBarMsg("(" + packages.Count + "/" + packages.Count + ") loading package files", 75);
            ProgressBarMsg("(" + packages.Count + "/" + packages.Count + ") checking for file conflicts", 20);
            ProgressBarMsg("(" + packages.Count + "/" + packages.Count + ") checking available disk space", 15);
            Console.WriteLine(":: Processing package changes...");
            Thread.Sleep(450);
            for (int i = 0; i<packages.Count-1;i++)
            {
                ProgressBarMsg("(" + (i+1) + "/" + packages.Count + ") updating "+packages[i], 20);
            }
            ProgressBarMsg("(" + packages.Count + "/" + packages.Count + ") updating " + packages[packages.Count-1], 500);
            Console.WriteLine(":: Updating system failed, trying again in 5 seconds");
            Thread.Sleep(5000);
        }

        public static void ProgressBarMsg(string msg, int interval, bool isDownload = false)
        {
            Console.Write(msg+" ");
            var progress = new ProgressBar();
            for (int i = 0; i <= 99; i++)
            {
                progress.Report((double)i / 99);
                Thread.Sleep(interval);
            }
            Console.Write(System.Environment.NewLine);
        }
    }
}
