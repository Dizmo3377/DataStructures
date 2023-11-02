public struct Cell
{
    public bool hasBomb {  get; private set; }
    public Cell(bool hasBomb) => this.hasBomb = hasBomb;
}