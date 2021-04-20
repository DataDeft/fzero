namespace Fzero


type Game = {
  History: int list
  Rewards: int list
  ChildVisits: int list
  RootValues: int list
  Discount: float
}

type IGame =
  abstract Apply: game: Game -> action: int -> Game
  abstract LegalActions: unit -> int []
