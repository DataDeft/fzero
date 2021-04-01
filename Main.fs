namespace AlphaZeroBackGammon

// internal
open Cli
open Logging

//external
open System

module Main =


  type TreeNode = {
    Score : uint32
    Visits : uint32
    Ucb1 : float32
    Children: TreeNode[]
  }


  type RootNode = {
    Children: Option<TreeNode[]>
  }


  type Action = Move


  type Player = W | R


  type Checkers = {
    Owner: Player
    Count : uint8
  }


  type BoardState = {
    Middle: Option<Checkers> * Option<Checkers>
    Points : Option<Checkers>[]
    Bearing : Option<Checkers> * Option<Checkers>
    Concluded : bool
    Iterations : uint8
  }


  let random = Random()

  let initialState : BoardState =

    let one         = Some { Owner = R; Count = uint8(2) }
    let six         = Some { Owner = W; Count = uint8(5) }
    let eight       = Some { Owner = W; Count = uint8(3) }
    let twelve      = Some { Owner = R; Count = uint8(5) }
    let thirteen    = Some { Owner = W; Count = uint8(5) }
    let seventeen   = Some { Owner = R; Count = uint8(3) }
    let nineteen    = Some { Owner = R; Count = uint8(5) }
    let twentyfour  = Some { Owner = W; Count = uint8(2) }

    {
      Middle = (None, None)
      Points = [|
        one       ; None  ; None ; None ; None      ; six         ;
        None      ; eight ; None ; None ; None      ; twelve      ;
        thirteen  ; None  ; None ; None ; seventeen ; None        ;
        nineteen  ; None  ; None ; None ; None      ; twentyfour  ;
      |]
      Bearing = (None, None)
      Concluded = false
      Iterations = uint8(0)
    }


  let rollTheDice () =
    // seq { 0 .. 1 .. 1_000_000 } |> Seq.map (fun _ -> random.Next(1,7)) |> Set.ofSeq;; =>  Set<int> = set [1; 2; 3; 4; 5; 6]
    random.Next(1,7)


  let turn roll =
    1


  let rec whoGoesFirst ()  =

    // roll the dices
    let rollR = rollTheDice()
    let rollW = rollTheDice()

    let ret =
      match rollR, rollW with
      | rollR, rollW when rollR > rollW -> (R, rollR, rollW)
      | rollR, rollW when rollR < rollW -> (W, rollW, rollW)
      | _, _                            -> whoGoesFirst() // when rollB = rollW

    ret

  let loadNN () =
    1

  let rec startGame () =

    // this function determines if the game is over and returns the score
    // this is also triggering the saving of the resNet (once it is implemented)
    // TODO:
    // - load previous resNet
    // - calls whogoesfirst
    // - calls turn() until game concludes
    loadNN() |> ignore
    let firstStep = whoGoesFirst ()

    2

  let loggerMain =
    Logger.CreateLogger "Main" "info" (fun () -> DateTime.Now)

  [<EntryPoint>]
  let main argv =
    let commandLineArgumentsParsed = parseCommandLine (Array.toList argv)

    loggerMain.LogInfo
    <| sprintf "%A" commandLineArgumentsParsed

    startGame() |> ignore

    0
