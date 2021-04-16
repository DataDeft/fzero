namespace Fzero



module TicTacToe =

  let createGame () : TicTacToeState =
    (Array.init 9 (fun _ -> Empty))


  let actionSpace = 9


  let printBoard (gameState: TicTacToeState) =

    sprintf "| %A | %A | %A |\n" gameState.[0] gameState.[1] gameState.[2]
    + sprintf "   | %A | %A | %A |\n" gameState.[3] gameState.[4] gameState.[5]
    + sprintf "   | %A | %A | %A |" gameState.[6] gameState.[7] gameState.[8]


  let didAnyBodyWin (gameState:TicTacToeState) : option<Player> =
    match gameState with
    | [| Filled X; Filled X; Filled X; _; _; _; _; _; _; |] -> Some X
    | [| _; _; _; Filled X; Filled X; Filled X; _; _; _; |] -> Some X
    | [| _; _; _; _; _; _; Filled X; Filled X; Filled X; |] -> Some X
    | [| Filled X; _; _; Filled X; _; _; Filled X; _; _; |] -> Some X
    | [| _; Filled X; _; _; Filled X; _; _; Filled X; _; |] -> Some X
    | [| _; _; Filled X; _; _; Filled X; _; _; Filled X; |] -> Some X
    | [| Filled X; _; _; _; Filled X; _; _; _; Filled X; |] -> Some X
    | [| _; _; Filled X; _; Filled X; _; Filled X; _; _; |] -> Some X
    | [| Filled O; Filled O; Filled O; _; _; _; _; _; _; |] -> Some O
    | [| _; _; _; Filled O; Filled O; Filled O; _; _; _; |] -> Some O
    | [| _; _; _; _; _; _; Filled O; Filled O; Filled O; |] -> Some O
    | [| Filled O; _; _; Filled O; _; _; Filled O; _; _; |] -> Some O
    | [| _; Filled O; _; _; Filled O; _; _; Filled O; _; |] -> Some O
    | [| _; _; Filled O; _; _; Filled O; _; _; Filled O; |] -> Some O
    | [| Filled O; _; _; _; Filled O; _; _; _; Filled O; |] -> Some O
    | [| _; _; Filled O; _; Filled O; _; Filled O; _; _; |] -> Some O
    | _                                                     -> None


  let otherPlayer player =
    match player with
    | O -> X
    | X -> O


  let legalActions (gameState:TicTacToeState) =
     // There must be a shorter version
     gameState
      |> Seq.mapi  (fun i v -> i, v)
      |> Seq.filter (fun x -> (snd x) = Empty)
      |> Seq.map (fun x -> (fst x))

  let playerToGameState (player:Player) : TicTacToeAtom =

    match (player:Player) with
    | X -> Filled X
    | O -> Filled O


  let step (gameState:TicTacToeState) (action:Action) (player:Player) =

    // This is not thread safe to modify arrays

    match action with
    | Action ok ->
        gameState.[int(ok)] <- (playerToGameState player)
        let gameWonBy = didAnyBodyWin(gameState)
        let reward =
          match (gameWonBy, player) with
          | (Some X, X) | (Some O, O) -> 1
          | (Some X, O) | (Some O, X) -> -1
          | _ -> 0

        Some { Board = gameState; Player = player; GameWonBy = gameWonBy; Reward =  reward}

    | IllegalAction ->
        None


// let game = createGame();;

// val game : TicTacToeState =
//   [|Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty; Empty|]

// > step game (Action.Create 4) X;;
// val it : (TicTacToeState * TicTacToeAtom * TicTacToeAtom * int) option =
//   Some
//     ([|Empty; Empty; Empty; Empty; X; Empty; Empty; Empty; Empty|], X, Empty,
//      0)

// > step game (Action.Create 0) O;;
// val it : (TicTacToeState * TicTacToeAtom * TicTacToeAtom * int) option =
//   Some
//     ([|O; Empty; Empty; Empty; X; Empty; Empty; Empty; Empty|], O, Empty, 0)

// > step game (Action.Create 5) X;;
// val it : (TicTacToeState * TicTacToeAtom * TicTacToeAtom * int) option =
//   Some ([|O; Empty; Empty; Empty; X; X; Empty; Empty; Empty|], X, Empty, 0)

// > step game (Action.Create 1) O;;
// val it : (TicTacToeState * TicTacToeAtom * TicTacToeAtom * int) option =
//   Some ([|O; O; Empty; Empty; X; X; Empty; Empty; Empty|], O, Empty, 0)

// > step game (Action.Create 3) X;;
// val it : (TicTacToeState * TicTacToeAtom * TicTacToeAtom * int) option =
//   Some ([|O; O; Empty; X; X; X; Empty; Empty; Empty|], X, X, 1)




