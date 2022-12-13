using System;
using System.IO;

namespace MapBuilder
{
    internal class SnakeMapBuilder
    {

        public bool GenerateNewMap(int rows, int cols, char wallDrawingToken, string outputFile, string outPutPath)
        {
            
            using (var writer = new StreamWriter(outputFile))
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (row == 0 || row == rows - 1 || col == 0 || col == cols - 1)
                        {
                            writer.Write(wallDrawingToken);
                            continue;
                        }
                        writer.Write(' ');
                    }
                    writer.WriteLine();
                }
            }

            return true;
        }
    }
}