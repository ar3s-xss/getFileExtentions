using System;
using System.Collections;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Projekt1{
    public class Projekt1{
        public static void Main(string[] args){
            Console.WriteLine("Made by ares.\n");
            //  TODO: output also signatures
            /*
            Console.WriteLine(Recursion(1000));
            Console.WriteLine();
            */

            string[] files = ["crack_head_jesus.jpg", @"D:\csharp_projekty\bin\Debug\net8.0\csharp_projekty.exe", @"D:\csharp_projekty\bin\Debug\net8.0\testArchive.zip", @"D:\csharp_projekty\bin\Debug\net8.0\testArchive.7z", @"D:\csharp_projekty\bin\Debug\net8.0\testWordDocument.docx"];
            string picture = files[0];

            /*
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("my bits");
            Console.ResetColor();
            byte[] pictureBytes = PictureBytes(picture);
            BitArray bitArray = new(pictureBytes);
            int? y = 0;
            for (int x = 0; x < bitArray.Length; x++){
                Console.Write(bitArray[x] ? "1" : "0");
                y++;
            }
            Console.WriteLine();
            Console.WriteLine(Math.Ceiling((double)y / 8));
            */

            byte[] pictureBytes = GetFileBytes(args[0]);
            string magicBytes = GetMagicBytes(pictureBytes).ToString();

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("Magic Bytes :");
            Console.ResetColor();
            Console.Write(" ");
            Console.Write($"{magicBytes}\n");
            
            WhatFileItIs(magicBytes);
            
            

        }

        public static BigInteger Recursion(int R){
            if (R > 0){
                return R * Recursion(R - 1);
            }
            return 1;
        }

        
        public static byte[] PictureBytes(string picturePath){
            byte[] picBytes = File.ReadAllBytes(picturePath);
            return picBytes;
        }
        public static byte[] GetFileBytes(string picturePath){
            byte[] buffer = new byte[32];
            try{
                using(FileStream fs = new(picturePath, FileMode.Open, FileAccess.Read, FileShare.Read)){
                    fs.Read(buffer, 0, buffer.Length);
                }
                
            } catch (IOException e){
                Console.WriteLine(e.ToString());
                return Array.Empty<byte>();
            }
            return buffer;
        }

        public static string GetMagicBytes(byte[] pictureBytes){
            string fileMagicBytes = "";
            for (int i = 0; i < 16; i++)
            {
                fileMagicBytes += pictureBytes[i].ToString("X2");   
            }
            return fileMagicBytes;
        }

        public static void WhatFileItIs(string fileMagicBytes){
            MagicBytes objMagicBytes = new();
            List<string> semiMatches = new();
            string bestMatch = "Unknown file type";
            int bestMatchScore = 0;

            
            foreach (var item in objMagicBytes.magicBytes){
        
                int matchScore = GetMatchScore(fileMagicBytes, item.Value);

                if (matchScore > 0){
                    semiMatches.Add(item.Key);
                }
            }

    
            foreach (var item in objMagicBytes.magicBytes){
                int matchScore = GetMatchScore(fileMagicBytes, item.Value);

        
                if (matchScore > bestMatchScore){
                    bestMatch = item.Key;
                    bestMatchScore = matchScore;
                }
            }

            Console.WriteLine(bestMatch);

            semiMatches.Remove(bestMatch);     
            if (semiMatches.Count > 0){
                Console.WriteLine("This file also can be");
                foreach (var semiMatch in semiMatches){
                    Console.WriteLine("\t- " + semiMatch);
                }
            }
        
        }
        private static int GetMatchScore(string fileMagicBytes, string signature){
            int matchScore = 0;
            int comparisonLength = Math.Min(fileMagicBytes.Length, signature.Length);
            for (int i = 0; i < comparisonLength; i+=2){
                if (fileMagicBytes.Substring(i, 2) == signature.Substring(i, 2)){
                    matchScore++;
                } else {
                    break;
                }
            }
            return matchScore;
        }

    }
}
