using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CellularAutomaton
{
    internal sealed class CellularAutomaton : Panel
    {
        private readonly ToolTip _t1;
        private long _age;
        private Cell[,] _cells, _cellsCopy;
        //vars
        private byte _cellSize;
        private Rules _rule;
        private int _xCellsCount, _yCellsCount;


        //methods
        public CellularAutomaton()
        {
            BackColor = Color.Transparent;
            Dock = DockStyle.Fill;
            Location = new Point(0, 56);
            Name = "CellularAutomaton";
            Size = new Size(804, 480);
            TabIndex = 0;
            _cellSize = 30;
            Paint += _Paint;
            MouseDown += _MouseDown;
            MouseMove += CellularAutomaton_MouseMove;
            Resize += _Resize;
            InitCells();
            DefaultState = 0;
            MaxState = 4;
            Rule = Rules.TrokaAutomaton;
            CellsCount = 1000;
            _t1 = new ToolTip();
            _age = 0;
        }

        private byte MaxState { get; set; }
        public int DefaultState { get; set; }

        public long CellsCount
        {
            get { return _xCellsCount * _yCellsCount; }
            set
            {
                _cellSize = (byte) (Math.Sqrt(CellsCount / (double) value) * _cellSize);
                if (_cellSize == 0) _cellSize = 1;
                InitCells();
                Refresh();
            }
        }

        public Rules Rule
        {
            get { return _rule; }
            set
            {
                _rule = value;
                _ruleChanged();
            }
        }

        public void Evolution()
        {
            lock (this)
            {
                CreateCellsCopy();

                for (var y = 0; y < _yCellsCount; y++)
                for (var x = 0; x < _xCellsCount; x++)
                {
                    var neighborsInState = new int[MaxState + 1];

                    for (var i = 0; i < MaxState + 1; i++)
                        neighborsInState[i] = CountNeighborsInState(x, y, i);

                    //tutaj zasady ewolucji stanow

                    switch (Rule)
                    {
                        case Rules.TrokaAutomaton:
                            switch (_cells[x, y].State)
                            {
                                case 0:
                                    if (neighborsInState[1] >= 3)
                                        _cells[x, y].State = 1;
                                    break;

                                case 1:
                                    if (neighborsInState[1] >= 3)
                                        _cells[x, y].State = 0;
                                    else if (neighborsInState[2] > 1)
                                        _cells[x, y].State = 4;
                                    break;

                                case 2:
                                    if (neighborsInState[3] > 0 && neighborsInState[4] > 0)
                                        _cells[x, y].State = 3;
                                    break;

                                case 3:
                                    if (neighborsInState[4] == 0)
                                        _cells[x, y].State = 1;

                                    break;

                                case 4:
                                    if (neighborsInState[2] > 2)
                                        _cells[x, y].State = 2;
                                    else if (neighborsInState[1] > 2)
                                        _cells[x, y].State = 3;
                                    break;
                            }
                            break;

                        case Rules.GameOfLife:
                            switch (_cells[x, y].State)
                            {
                                case 0:
                                    /*Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.*/
                                    if (neighborsInState[1] == 3)
                                        _cells[x, y].State = 1;
                                    break;
                                case 1:
                                    /*Any live cell with fewer than two live neighbours dies, as if caused by under-population.*/
                                    if (neighborsInState[1] < 2)
                                        _cells[x, y].State = 0;
                                    /*Any live cell with more than three live neighbours dies, as if by overcrowding.*/
                                    else if (neighborsInState[1] > 3)
                                        _cells[x, y].State = 0;
                                    /*Any live cell with two or three live neighbours lives on to the next generation.*/
                                    break;
                            }
                            break;

                        case Rules.Darwinia:
                            break;

                        case Rules.HeatTransfer:
                            switch (_cells[x, y].State)
                            {
                                case 0: //pustka (slabo przewodzi)
                                    if (neighborsInState[2] >= 3 && neighborsInState[2] > neighborsInState[3])
                                        _cells[x, y].State = 2;
                                    else if (neighborsInState[3] >= 3 && neighborsInState[3] > neighborsInState[2])
                                        _cells[x, y].State = 3;
                                    break;

                                case 1: //przewodnik
                                    if (neighborsInState[2] > neighborsInState[3]) //cieplo jest
                                        _cells[x, y].State = 2; //staje sie cieply
                                    else if (neighborsInState[2] < neighborsInState[3]) //zimno jest
                                        _cells[x, y].State = 3; //staje sie zimny
                                    break;

                                case 2: //ciepło
                                    if (neighborsInState[1] >= 2)
                                        _cells[x, y].State = 0;
                                    else if (neighborsInState[3] >= neighborsInState[2] + 1) //jest dosyć zimno
                                        _cells[x, y].State = 0; //więc wytraciło swoje ciepło (ale nie jest zimne)
                                    else if (neighborsInState[2] < 3)
                                        _cells[x, y].State = 0;
                                    break;

                                case 3: //zimno
                                    if (neighborsInState[1] >= 2)
                                        _cells[x, y].State = 0;
                                    else if (neighborsInState[3] + 1 <= neighborsInState[2]) //jest dosyć ciepło
                                        _cells[x, y].State = 0; //więc się ogrzało (ale nie jest ciepłe)
                                    else if (neighborsInState[3] < 3)
                                        _cells[x, y].State = 0;

                                    break;

                                case 4: //przegroda
                                    break;
                            }
                            break;

                        case Rules.QuadLife:
                            switch (_cells[x, y].State)
                            {
                                case 0:
                                    if (neighborsInState[1] + neighborsInState[2] + neighborsInState[3] +
                                        neighborsInState[4] == 3)
                                        if (neighborsInState[1] >= 2)
                                        {
                                            _cells[x, y].State = 1;
                                        }
                                        else if (neighborsInState[2] >= 2)
                                        {
                                            _cells[x, y].State = 2;
                                        }
                                        else if (neighborsInState[3] >= 2)
                                        {
                                            _cells[x, y].State = 3;
                                        }
                                        else if (neighborsInState[4] >= 2)
                                        {
                                            _cells[x, y].State = 4;
                                        }
                                        else
                                        {
                                            if (neighborsInState[1] == 0)
                                                _cells[x, y].State = 1;
                                            if (neighborsInState[2] == 0)
                                                _cells[x, y].State = 2;
                                            if (neighborsInState[3] == 0)
                                                _cells[x, y].State = 3;
                                            if (neighborsInState[4] == 0)
                                                _cells[x, y].State = 4;
                                        }
                                    break;

                                default:
                                    /*Any live cell with fewer than two live neighbours dies, as if caused by under-population.*/
                                    if (neighborsInState[1] + neighborsInState[2] + neighborsInState[3] +
                                        neighborsInState[4] < 2)
                                        _cells[x, y].State = 0;
                                    /*Any live cell with more than three live neighbours dies, as if by overcrowding.*/
                                    else if (neighborsInState[1] + neighborsInState[2] + neighborsInState[3] +
                                             neighborsInState[4] > 3)
                                        _cells[x, y].State = 0;
                                    /*Any live cell with two or three live neighbours lives on to the next generation.*/
                                    break;
                            }
                            break;


                        case Rules.Wireworld:
                            switch (_cells[x, y].State)
                            {
                                case 0: //pustka, nic sie nie dzieje
                                    break;

                                case 1: //przewodnik
                                    if (neighborsInState[2] == 1 || neighborsInState[2] == 2)
                                        _cells[x, y].State = 2;
                                    break;

                                case 2: //głowa elektronu
                                    _cells[x, y].State = 3;
                                    break;

                                case 3: //ogon elektronu
                                    _cells[x, y].State = 1;
                                    break;

                                case 4: //izolator
                                    break;
                            }
                            break;
                    }
                }
                Refresh();
            }
            _age++;
        }

        public void RandomizeStates()
        {
            var rnd = new Random();

            for (var y = 0; y < _yCellsCount; y++)
            for (var x = 0; x < _xCellsCount; x++)
                _cells[x, y].State = rnd.Next(0, MaxState + 1);
        }

        public List<string> GetStates()
        {
            var statesList = new List<string> {"cell A", "cell B", "cell C", "cell D", "cell E"};

            return statesList;
        }

        public List<Rules> GetRules()
        {
            return Enum.GetValues(typeof(Rules)).Cast<Rules>().ToList();
        }

        private int CountNeighborsInState(int x, int y, int state)
        {
            var count = 0;

            for (var ix = -1; ix < 2; ix++)
            for (var iy = -1; iy < 2; iy++)
                if (!(ix == 0 && iy == 0)) //nie liczymy środka
                    if (x + ix >= 0 && x + ix < _xCellsCount && y + iy >= 0 && y + iy < _yCellsCount)
                        //nie wychodzimy poza tablice
                        if (_cellsCopy[x + ix, y + iy].State == state)
                            count++;
            return count;
        }

        private void InitCells()
        {
            var left = 0;
            var top = 0;

            _xCellsCount = Size.Width / _cellSize;
            _yCellsCount = Size.Height / _cellSize;
            _cells = new Cell[_xCellsCount, _yCellsCount];
            _cellsCopy = new Cell[_xCellsCount, _yCellsCount];

            for (var y = 0; y < _yCellsCount; y++)
            {
                left = 0;
                for (var x = 0; x < _xCellsCount; x++)
                {
                    _cells[x, y] = new Cell(left, top, _cellSize, _cellSize);
                    left += _cellSize;
                }
                top += _cellSize;
            }
            CreateCellsCopy();
        }

        private void CreateCellsCopy()
        {
            for (var y = 0; y < _yCellsCount; y++)
            for (var x = 0; x < _xCellsCount; x++)
                _cellsCopy[x, y] = new Cell(_cells[x, y]);
        }

        private void ResizeCells()
        {
            _cellSize = (byte) ((Size.Width / _xCellsCount + Size.Height / _yCellsCount) / 2);

            var left = 0;
            var top = 0;
            for (var y = 0; y < _yCellsCount; y++)
            {
                left = 0;
                for (var x = 0; x < _xCellsCount; x++)
                {
                    _cells[x, y] = new Cell(_cells[x, y], left, top, _cellSize, _cellSize);
                    left += _cellSize;
                }
                top += _cellSize;
            }
            var a = 1 + 1;
        }

        private void _ruleChanged()
        {
            switch (Rule)
            {
                case Rules.TrokaAutomaton:
                    MaxState = 4;
                    break;

                case Rules.GameOfLife:
                    for (var y = 0; y < _yCellsCount; y++)
                    for (var x = 0; x < _xCellsCount; x++)
                        if (_cells[x, y].State > 0)
                            _cells[x, y].State = 1;
                    MaxState = 1;

                    break;

                case Rules.Darwinia:
                    MaxState = 4;
                    break;

                case Rules.HeatTransfer:
                    MaxState = 4;
                    break;
            }
        }

        private void _Resize(object sender, EventArgs e)
        {
            ResizeCells();
            Refresh();
        }

        private void _MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                for (var y = 0; y < _yCellsCount; y++)
                for (var x = 0; x < _xCellsCount; x++)
                    if (_cells[x, y].Shape.Contains(e.Location))
                    {
                        if (e.Button == MouseButtons.Left)
                            _cells[x, y].State = DefaultState;
                        else if (e.Button == MouseButtons.Right)
                            _cells[x, y].State = 0;
                        Invalidate();
                    }
        }

        private void CellularAutomaton_MouseMove(object sender, MouseEventArgs e)
        {
            for (var y = 0; y < _yCellsCount; y++)
            for (var x = 0; x < _xCellsCount; x++)
                if (_cells[x, y].Shape.Contains(e.Location))
                    _t1.Show(
                        "(" + "x=" + x + " " + "y=" + y + "); \n number of neighbors: \n(s=0 : " +
                        CountNeighborsInState(x, y, 0) + "\n s=1 : " + CountNeighborsInState(x, y, 1) + ")\n Epoch=" +
                        _age, this);
        }

        private void _Paint(object sender, PaintEventArgs e)
        {
            for (var y = 0; y < _yCellsCount; y++)
            for (var x = 0; x < _xCellsCount; x++)
            {
                e.Graphics.FillRectangle(_cells[x, y].Brush, _cells[x, y].Shape);
                if (_cellSize >= 20)
                    ControlPaint.DrawBorder3D(e.Graphics, _cells[x, y].Shape, Border3DStyle.Raised,
                        Border3DSide.Left | Border3DSide.Top | Border3DSide.Right | Border3DSide.Bottom);
            }
        }
    }
}