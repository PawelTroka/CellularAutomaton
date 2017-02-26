using System.Drawing;

namespace CellularAutomaton
{
    internal class Cell //: Rectangle
    {
        private int _age;
        private Color _color;
        private int _state;


        public Cell(int x, int y, int width, int height)
        {
            _color = Color.White;
            Shape = new Rectangle(x, y, width, height);
            Brush = new SolidBrush(_color);
            State = 0;
        }

        public Cell(Cell copyCell, int x, int y, int width, int height)
        {
            Brush = copyCell.Brush;
            _color = copyCell._color;
            _state = copyCell.State;
            Shape = new Rectangle(x, y, width, height);
        }


        public Cell(Cell copyCell)
        {
            Brush = copyCell.Brush;
            _color = copyCell._color;
            _state = copyCell.State;
            Shape = new Rectangle(copyCell.Shape.X, copyCell.Shape.Y, copyCell.Shape.Width, copyCell.Shape.Height);
        }

        public SolidBrush Brush { get; }

        public Rectangle Shape { get; set; }

        public int State
        {
            get { return _state; }
            set
            {
                _state = value;
                _stateChanged();
            }
        }

        public void GrowOlder()
        {
            _age++;
        }

        public int GetAge()
        {
            return _age;
        }

        private void _stateChanged()
        {
            switch (State)
            {
                case 0:
                    _color = Color.White;
                    break;

                case 1:
                    _color = Color.Green;
                    break;

                case 2:
                    _color = Color.Red;
                    break;

                case 3:
                    _color = Color.Blue;
                    break;

                case 4:
                    _color = Color.Black;
                    break;
            }
            Brush.Color = _color;
        }
    }
}