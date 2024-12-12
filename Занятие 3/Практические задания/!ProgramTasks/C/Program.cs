namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteTextWithBorder("Menu:");
            WriteTextWithBorder("");
            WriteTextWithBorder(" ");
            WriteTextWithBorder("Game Over!");
            WriteTextWithBorder("Select level:");
        }

        private static void WriteTextWithBorder(string text)
        {
            using namespace std;
            void customFunk(const char *text) 
            {
                cout << "+-";
                for (int i = 0; i < strlen(text); i++) 
                {
                    cout << "-";
                }
                cout << "-+" << endl;

                printf("| %s |", text);
                cout << endl << "+-";
                for (int i = 0; i < strlen(text); i++)
                {
                    cout << "-";
                }
                cout << "-+" << endl;
            }
            int main()
            {
                customFunk("Hello World!");
                return 0;
            }
        }
    }
}
