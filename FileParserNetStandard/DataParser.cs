using System.Collections.Generic;
using System.Linq;
using ObjectLibrary;

namespace FileParserNetStandard {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data)
        {

            for(int row = 0; row <data.Count; row++)
            {
                for (int index = 0; index < data[row].Count; index++)
                {
                    data[row][index] = data[row][index].Trim();
                }
            }

            return data;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data)
        {
            for (int row = 0; row < data.Count; row++)
            {
                for (int index = 0; index < data[row].Count; index++)
                {
                    data[row][index] = data[row][index].Trim('"');
                }
            }
            return data;
        }

    }
}