using System;
 
namespace Rectangles
{
    public static class RectanglesTask
    {
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            //Поскольку  обычное ветвление получается очень громозским и даже с комментами 
            //очень не удобным, принято решение пойти от обратного и реализовать короткий, лаконичный и понятный метод
            //Задаем 4 булевы переменные для определения ...
            //Не слишком ли левее
            bool tooLeft = r1.Left > r2.Left + r2.Width;
            //превее
            bool tooRight = r2.Left > r1.Left + r1.Width;
            //выше
            bool tooHigh = r1.Top > r2.Top + r2.Height;
            //или ниже находится прямоугольник
            bool tooLow = r2.Top > r1.Top + r1.Height;
            //Если хоть 1 переменная истинна то она вернется с помощью логического или
            //Но, метод построен от обратного, по этому используется отрицание
            return !(tooLeft || tooRight || tooHigh || tooLow);
        }
 
        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            if (AreIntersected(r1, r2) == true)
            {
                //По скольку в условии задания не было запрещено создавать собственные методы
                //был создан метод SearchIntersection который находит пересечения отрезков
                //по переданным в него аргументам.
                //этот же метод используя метод SearchIntersection находит пересечения отрезков 
                //и перемножает их для получения площади пересечения
                int xPere = SearchIntersection(r1.Left, r1.Right, r2.Left, r2.Right);
                int yPere = SearchIntersection(r1.Top, r1.Bottom, r2.Top, r2.Bottom);
                return xPere * yPere;
            }
            else return 0;
            int SearchIntersection(int aLeft, int aRight, int bLeft, int bRight)
            {
                int left = Math.Max(aLeft, bLeft);
                int right = Math.Min(aRight, bRight);
 
                return Math.Max(right - left, 0);
            }
        }
        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            //в этом методе в первую очередь реализована проверка на площадь соприкосновения,
            //так-как если она не >=1 то и 1 из прямоугольников не может быть внутри второго
            if ((IntersectionSquare(r1, r2)) > 0)
            {
                //Здесь идет проверка путем сравнивания площади соприкосновения и площадей 
                //прямоугольников. Получених из Left*Top и Width*Height
                //С уточнениями для маленьких внутри              
                if ((IntersectionSquare(r1, r2)) == (r1.Left * r1.Top) && (r1.Left * r1.Top >= r1.Width * r1.Height))
                {
                    if ((r1.Left == 1) || (r1.Top == 1)) return -1;
                    else return 0;
                }
                if ((IntersectionSquare(r1, r2)) == (r2.Left * r2.Top) && (r2.Left * r2.Top >= r2.Width * r2.Height))
                {
                    if ((r2.Left == 1) || (r2.Top == 1)) return 1;
                    else return 1;
                }
                if ((IntersectionSquare(r1, r2)) == (r1.Width * r1.Height) && (r1.Width * r1.Height >= r1.Left * r1.Top))
                {
                    if ((r1.Width == 1) || (r1.Height == 1)) return -1;
                    else return 0;
                }
                if ((IntersectionSquare(r1, r2)) == (r2.Width * r2.Height) && (r2.Width * r2.Height >= r2.Left * r2.Top))
                {
                    if ((r2.Width == 1) || (r2.Height == 1)) return -1;
                    else return 1;
                }
                else return -1;
            }
            if (r2.Height == 0 && r2.Width == 0) return 1;
            if (r1.Height == 0 && r1.Width == 0) return 0;
            if ((IntersectionSquare(r1, r2)) == (r2.Width * r2.Height) ^ (r2.Width * r2.Height >= r2.Left * r2.Top)) return -1;
            
            else return -1;
        }
    }
}
