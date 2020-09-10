using System;
using System.Collections.Generic;
using System.Text;

namespace PdfCreator
{
    public static class Constants
    {
        //Error
        public static string NO_INPUTS_TO_MAP_ERROR = "InputMapper.MapInputFromArray received no inputs.";
        public static string NO_COMMANDS_TO_PROCESS_ERROR = "PdfGenerator.BuildPdf received no commands.";
        public static string EMPTY_INPUT_ERROR = "The input file at {0} was empty. Please give it some contents and re-run the program.";

        //Config
        public static string INPUT_FILE_NAME_SETTING = "inputFilePath";
        public static string OUTPUT_FILE_NAME_SETTING = "outputFilePath";

        //Command names
        public static string INDENTATION_COMMAND_NAME = ".indent";
    }
}
