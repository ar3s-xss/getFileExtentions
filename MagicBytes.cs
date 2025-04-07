using Projekt1;

 internal class MagicBytes{
    internal Dictionary<string,string> magicBytes = new Dictionary<string, string>{
       {"This is a (JPG/JPEG) file", "FFD8FFDB"},
       {"This is a (JPG)/(JPEG) file", "FFD8FFE000104A4649460001"},
       {"This is a JPG/JPEG", "FFD8FFEE"},
       {"This is a EXE file", "4D5A"},
       {"this is a DLL file", "4D5A"},
       {"This is a PNG file", "89504E470D0A1A0A"},
       {"This is a (GIF) file", "474946383961"},
       {"This is a GIF file", "474946383761"},
       {"This is a PDF file", "255044462D"},
       {"This is a C source file", ""},
       {"This is a C++ source file", ""},
       {"This is a C# source file", ""},
       {"This is a JAVA JAR file", "504B0304140000080800"},
       {"This is a JAVA class file", "504B0304140000080800"},
       {"This is a JAVA source file", "7075626C696320636C617373206"},
       {"This is a XML UTF-8 file", "3C3F786D6C20"},
       {"This is a XML UTF-16LE file", "3C003F0078006D006C0020"},
       {"This is a XML UTF-16BE file", "003C003F0078006D006C0020"},
       {"This is a XML UTF-32LE file", "3C0000003F000000780000006D0000006C00000020000000"},
       {"This is a XML UTF-32BE file", "0000003C0000003F000000780000006D0000006C00000020"},
       {"This is a XML (EBCDIC) file", "4C6FA7949340"},
       {"This is a ZIP file", "504B0304"},
       {"This is a 7ZIP file", "377ABCAF271C"},
       {"This is a DOCX file", "504B030414000600080000002100"},
       {"MagicBytes", "File description"}
    };

}