using System.Text.RegularExpressions;
using UnityEngine;

namespace NSMB.Utils {
    public static class StringExtensions {

        public static string Filter(this string input) {
            if (Settings.Instance.filter)
                return ChatFilter.FilterString(input);

            return input;
        }

        public static bool IsValidUsername(this string input) {
            if (input == null)
                return false;

            string count = MainMenuManager.NICKNAME_MIN + "," + MainMenuManager.NICKNAME_MAX;
            return Regex.IsMatch(input, "^[0-9A-Za-z_]{" + count + "}(\\([0-9]+\\))?$");
        }

        public static string ToValidUsername(this string input) {
            //valid characters
            input = Regex.Replace(input, "[^0-9A-Za-z_]", "");

            //name character maximum
            input = input.Substring(0, Mathf.Min(input.Length, MainMenuManager.NICKNAME_MAX));

            //name character minimum
            if (input.Length < MainMenuManager.NICKNAME_MIN)
                input += new string('#', MainMenuManager.NICKNAME_MIN - input.Length);

            //name filtering
            input = input.Filter();

            return input;
        }
    }
}