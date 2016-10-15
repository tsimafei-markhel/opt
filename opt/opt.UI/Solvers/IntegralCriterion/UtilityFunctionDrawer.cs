using System.Drawing;
using System.Drawing.Drawing2D;

namespace opt.Solvers.IntegralCriterion
{
    public abstract class UtilityFunctionDrawer
    {
        /// <summary>
        /// Метод для построения графика функции полезности. 
        /// ЦИФРЫ ЗАХАРДКОЖЕНЫ
        /// </summary>
        /// <param name="graphics">Объект Graphics для рисования</param>
        /// <param name="utFunc">Функция полезности</param>
        public static void DrawUtilityFunction(
            Graphics graphics,
            UtilityFunction utFunc)
        {
            var backBuffer = new Bitmap(590, 250);
            Graphics gr = Graphics.FromImage(backBuffer);

            // Отступ от верхней границы пикчурбокса до 
            // верхнего конца оси ординат, px
            const float yYAxisTop = 15.0F;
            // Отступ от верхнего конца оси ординат до 
            // отметки 1.00, px
            const float yOneMark = 15.0F;
            // Отступ от отметки 1.00 до отметки 0.00, px
            const float yZeroMark = 200.0F;
            // Отступ от левой границы пикчурбокса до 
            // начала оси абсцисс, px
            const float xXAxisBegin = 30.0F;
            // Отступ от начала оси абсцисс до первой отметки, px
            const float xFirstMark = 10.0F;
            // Отступ от первой отметки до конца оси абсцисс, px
            const float xXAxisEnd = 530.0F;
            // Интервал между отметками на оси абсцисс, px
            const float xStep = 53.0F;

            // Цвет осей координат
            var axisColor = Color.Black;
            // Толщина осей координат, px
            const float axisThickness = 2.0F;
            // Цвет линий графика функции полезности
            var funcColor = Color.Green;
            // Толщина линий графика функции полезности, px
            const float funcThickness = 1.0F;
            // Цвет точек на графике функции полезности
            var funcPointColor = Color.Green;
            // Диаметр точек на графике функции полезности, px
            const float funcPointDiameter = 8.0F;
            // Радиус точек на графике функции полезности, px
            const float funcPointRadius = 4.0F;

            // Очистка
            gr.Clear(Color.White);

            // Нарисуем оси координат
            var axisPen = new Pen(axisColor, axisThickness);
            var yAxisTop = new PointF(xXAxisBegin, yYAxisTop);
            var yAxisBottom = new PointF(xXAxisBegin, yYAxisTop + yOneMark + yZeroMark);
            gr.DrawLine(axisPen, yAxisTop, yAxisBottom);
            var xAxisBegin = new PointF(yAxisTop.X, yAxisBottom.Y);
            var xAxisEnd = new PointF(yAxisTop.X + xFirstMark + xXAxisEnd, yAxisBottom.Y);
            gr.DrawLine(axisPen, xAxisBegin, xAxisEnd);
            // Сделаем отметки и подписи
            axisPen.Width = 1.0F;
            var textFont = new Font("Times New Roman", 8.0F);
            var tickBegin = new PointF(xAxisBegin.X - 3.0F, yAxisTop.Y + yOneMark);
            var tickEnd = new PointF(xAxisBegin.X + 2.0F, yAxisTop.Y + yOneMark);
            gr.DrawLine(axisPen, tickBegin, tickEnd);
            var textPosition = new PointF(tickBegin.X - 24.0F, tickBegin.Y - 7.0F);
            gr.DrawString("1.00", textFont, Brushes.Black, textPosition);
            textPosition.Y += yZeroMark;
            gr.DrawString("0.00", textFont, Brushes.Black, textPosition);
            tickBegin.X = xAxisBegin.X + xFirstMark - xStep;
            tickBegin.Y = xAxisBegin.Y - 3.0F;
            tickEnd.X = tickBegin.X;
            tickEnd.Y = xAxisBegin.Y + 2.0F;
            for (int tickNum = 0; tickNum < 10; tickNum++)
            {
                tickBegin.X += xStep;
                tickEnd.X = tickBegin.X;
                gr.DrawLine(axisPen, tickBegin, tickEnd);
            }

            // Нарисуем график функции
            var firstPoint = new PointF(0.0F, 0.0F);
            var secondPoint = new PointF(0.0F, 0.0F);
            var linePen = new Pen(funcColor, funcThickness);
            Brush pointBrush = new SolidBrush(funcPointColor);
            int pointCalc = 0;
            foreach (double utFuncValue in utFunc.FixedPoints.Values)
            {
                secondPoint.X = xXAxisBegin + xFirstMark + pointCalc * xStep;
                secondPoint.Y = yYAxisTop + yOneMark + yZeroMark - (float)utFuncValue * yZeroMark;
                if (firstPoint.X != 0.0F && firstPoint.Y != 0.0F)
                {
                    // Это не первая точка, можно рисовать линию
                    gr.DrawLine(linePen, firstPoint, secondPoint); 
                }
                // Поставим точку
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.FillEllipse(
                    pointBrush,
                    secondPoint.X - funcPointRadius,
                    secondPoint.Y - funcPointRadius,
                    funcPointDiameter,
                    funcPointDiameter);
                gr.SmoothingMode = SmoothingMode.Default;
                // Присвоим первой точке координаты второй,
                // чтобы на следующем шаге можно было рисовать 
                // линию
                firstPoint.X = secondPoint.X;
                firstPoint.Y = secondPoint.Y;
                // Увеличим счетчик точек на 1
                pointCalc++;
            }

            // Наконец отрисуем всё что надо на пикчурбоксе
            graphics.DrawImageUnscaled(backBuffer, 0, 0);
        }
    }
}
