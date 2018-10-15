using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_de_usuario
{
    public partial class Grafica : Form
    {

        private NoFlickerPanel drawSurface;
        private Bitmap gridLayer;
        private Bitmap linesLayer;
        private List<PointF> points;
        private String nombreEjeX;
        private String nombreEjeY;
        private int gridCellCountX = 21;
        private int gridCellCountY = 21;
        private int gridCellCountSinMinY = 21;

        private const int cellSizeInPixels = 40;
        private const int windowXBoundryInPixels = 60;
        private const int windowYBoundryInPixels = 100;
        private const int drawSurfaceMaringToWindowInPixels = 40;
        private const int gridLinesMarginToLayerInPixels = 1;


        public Grafica(List<float> pointsX, List<float> pointsY, String nombreEjeX, String nombreEjeY)
        {
            
            InitializeComponent();
            this.nombreEjeX = nombreEjeX;
            this.nombreEjeY = nombreEjeY;
            CalcularGridCellCount(pointsX, pointsY);
            int drawSurfaceSizeX = cellSizeInPixels * gridCellCountX;
            int drawSurfaceSizeY = cellSizeInPixels * gridCellCountY;
            CreateDrawSurface(drawSurfaceSizeX, drawSurfaceSizeY);
            AdjustWindowSize(drawSurfaceSizeX, drawSurfaceSizeY);

            CreateOrRecreateLayer(ref gridLayer);
            PaintGrid();
            CreateOrRecreateLayer(ref linesLayer);
            CrearPoints(pointsX, pointsY);

            PaintLines();
        }
        private void CalcularGridCellCount(List<float> pointsX, List<float> pointsY)
        {
            gridCellCountX = (int)Math.Round(pointsX.Max())+ 5;
            gridCellCountSinMinY = (int)Math.Round(pointsY.Max()) + 5;
            int min = 0;
            if(pointsY.Min() < 0)
            {
                min = (int)Math.Floor(pointsY.Min()) - 5;
            }
            gridCellCountY = gridCellCountSinMinY + min *(-1);
        }


        private void CreateDrawSurface(int drawSurfaceSizeX, int drawSurfaceSizeY)
        {
            drawSurface = new NoFlickerPanel();
            SuspendLayout();
            drawSurface.Name = "drawSurface";
            drawSurface.Location = new Point(drawSurfaceMaringToWindowInPixels, drawSurfaceMaringToWindowInPixels);
            drawSurface.Size = new Size(drawSurfaceSizeX, drawSurfaceSizeY);
            drawSurface.TabIndex = 0;
            drawSurface.Paint += new PaintEventHandler(drawSurface_Paint);

            Controls.Add(drawSurface);
            ResumeLayout(false);
        }

        private void AdjustWindowSize(int drawSurfaceSizeX, int drawSurfaceSizeY)
        {
            int windowSizeX = drawSurfaceSizeX + drawSurfaceMaringToWindowInPixels * 2;
            int windowSizeY = drawSurfaceSizeY + drawSurfaceMaringToWindowInPixels * 2;
            MaximumSize = new Size(windowSizeX + windowXBoundryInPixels, windowSizeY + windowYBoundryInPixels);
            AutoScrollMargin = new Size(drawSurfaceMaringToWindowInPixels, drawSurfaceMaringToWindowInPixels);
           
        }
        private void CrearPoints(List<float> pointsX, List<float> pointsY)
        {
            points = new List<PointF>();
            for (int i = 0; i < pointsX.Count(); i++)
            {
                points.Add(new PointF(pointsX[i], pointsY[i]));
            }
        }

        private void PaintGrid()
        {

            using (Graphics graphics = Graphics.FromImage(gridLayer))
            {
                for (int i = 0; i < gridCellCountY - 1; i++)
                {
                    DrawGridHorizontalLines(graphics, i);
                }
                for (int i = 1; i < gridCellCountX; i++)
                {
                    DrawGridVerticalLines(graphics, i);
                }
                DrawGridRightAndBottomLines(graphics);
                DrawEjesLines(graphics);
            }
            drawSurface.Invalidate();
        }

        private void DrawGridHorizontalLines(Graphics graphics, int axis)
        {
            DrawHorizontalLine(graphics, axis, gridLinesMarginToLayerInPixels, Pens.LightGray);
        }
        private void DrawGridVerticalLines(Graphics graphics, int axis)
        {
            DrawVerticalLine(graphics, axis, 0, Pens.LightGray);
        }

        private void DrawGridRightAndBottomLines(Graphics graphics)
        {
            DrawHorizontalLine(graphics, gridCellCountY - 1, -gridLinesMarginToLayerInPixels, Pens.LightGray);
            DrawVerticalLine(graphics, gridCellCountX, -gridLinesMarginToLayerInPixels, Pens.LightGray);
        }
        private void DrawEjesLines(Graphics graphics)
        {
            Pen p = new Pen(Color.Black);
            p.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(10, 10);

            DrawHorizontalLine(graphics, gridCellCountSinMinY - 1, -gridLinesMarginToLayerInPixels, p);
            DrawVerticalLine(graphics, 1, -gridLinesMarginToLayerInPixels, p);
            int gridHeight = cellSizeInPixels * gridCellCountSinMinY;
            graphics.DrawString(nombreEjeX, new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular), Brushes.Black, gridLayer.Width / 2, gridHeight - 20);
            graphics.DrawString(nombreEjeY, new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular), Brushes.Black, 0, gridHeight / 2);
        }


        private void DrawHorizontalLine(Graphics graphics, int axis, int offset, Pen color)
        {
            int gridCellHeight = axis * gridLayer.Height / gridCellCountY + offset;
            int gridHeight = cellSizeInPixels * gridCellCountSinMinY;
            int valorEjeY = gridCellCountSinMinY - axis - 1;
            graphics.DrawLine(color, 40, gridCellHeight, gridLayer.Width, gridCellHeight);
            graphics.DrawString("" + valorEjeY, new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular), Brushes.Black, 20, gridCellHeight);

        }

        private void DrawVerticalLine(Graphics graphics, int axis, int offset, Pen color)
        {
            int gridCellWidth = axis * gridLayer.Width / gridCellCountX + offset;
            int valorEjeX = axis - 1;
            int gridHeight = cellSizeInPixels * gridCellCountSinMinY;
            graphics.DrawLine(color, gridCellWidth, gridLayer.Height - 40, gridCellWidth, 0);
            graphics.DrawString("" + valorEjeX, new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular), Brushes.Black, gridCellWidth, gridHeight - 40);

        }


        private void drawSurface_Paint(object sender, PaintEventArgs e)
        {
            PointF zeroing = new PointF(0, 0);
            e.Graphics.DrawImage(gridLayer, zeroing);
            e.Graphics.DrawImage(linesLayer, zeroing);
        }

        private void PaintLines()
        {
            CreateOrRecreateLayer(ref linesLayer);
            using (Graphics graphics = Graphics.FromImage(linesLayer))
            {
                int gridHeight = cellSizeInPixels * gridCellCountSinMinY;
                for (int i = 1; i < points.Count; i++)
                {
                   
                    float pointX1 = points[i - 1].X * 40 + 40;
                    float pointY1 = gridHeight - 40 * points[i - 1].Y - 40;
                    float pointX2 = points[i].X * 40 + 40;
                    float pointY2 = gridHeight - 40 * points[i].Y - 40;
                    float x = points[i - 1].X;
                    graphics.FillRectangle(Brushes.Black, pointX1, pointY1, 5, 5);
                    graphics.DrawLine(Pens.Red, pointX1, pointY1, pointX2, pointY2);
                    graphics.DrawString("(" + x + "," + points[i - 1].Y + ")", new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular), Brushes.Black, pointX1, pointY1);
                }
                float pointX = points[points.Count - 1].X * 40 + 40;
                float pointY = gridHeight - 40 * points[points.Count - 1].Y - 40;
                graphics.FillRectangle(Brushes.Black, pointX, pointY, 5, 5);
                graphics.DrawString("(" + points[points.Count - 1].X + "," + points[points.Count - 1].Y + ")", new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular), Brushes.Black, pointX, pointY);
            }
            drawSurface.Invalidate();
        }

        private void CreateOrRecreateLayer(ref Bitmap layer)
        {
            try
            {
                layer.Dispose();
            }
            catch (Exception)
            {
            }
            finally
            {
                layer = new Bitmap(drawSurface.Width, drawSurface.Height);
            }
        }

        private void Grafica_Load(object sender, EventArgs e)
        {

        }
    }
}



