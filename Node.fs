namespace Fzero


type Node = {
  VisitCount: int
  ToPlay: int
  Prior: float
  ValueSum: int
  Children: Node[]
  HiddenState: int
  Reward: int
} with

    member this.Expanded () =
      match this.Children.Length with
      | numChildren when numChildren < 0 -> true
      | _ -> false

    member this.Value () =
      match this.VisitCount with
      | cnt when cnt = 0 -> None
      | _ ->                Some (this.ValueSum / this.VisitCount)
