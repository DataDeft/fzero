namespace Fzero



module TicTacToe =

  let createGame () : TicTacToeState =
    (Array.init 9 (fun _ -> None))


  let actionSpace = 9


  let didAnyBodyWin (gameState:TicTacToeState) =
    match gameState with
    | [| X; X; X; _; _; _; _; _; _; |] -> X
    | [| _; _; _; X; X; X; _; _; _; |] -> X
    | [| _; _; _; _; _; _; X; X; X; |] -> X
    | [| X; _; _; X; _; _; X; _; _; |] -> X
    | [| _; X; _; _; X; _; _; X; _; |] -> X
    | [| _; _; X; _; _; X; _; _; X; |] -> X
    | [| X; _; _; _; X; _; _; _; X; |] -> X
    | [| _; _; X; _; X; _; X; _; _; |] -> X
    | [| O; O; O; _; _; _; _; _; _; |] -> O
    | [| _; _; _; O; O; O; _; _; _; |] -> O
    | [| _; _; _; _; _; _; O; O; O; |] -> O
    | [| O; _; _; O; _; _; O; _; _; |] -> O
    | [| _; O; _; _; O; _; _; O; _; |] -> O
    | [| _; _; O; _; _; O; _; _; O; |] -> O
    | [| O; _; _; _; O; _; _; _; O; |] -> O
    | [| _; _; O; _; O; _; O; _; _; |] -> O
    | _                              -> None


  let otherPlayer player =
    match player with
    | O -> X
    | X -> O
    | None -> None


  let step (gameState:TicTacToeState) (act:int) (player:TicTacToeAtom) =

    // This is not thread safe to modify arrays

    gameState.[act] <- player

    let gameWonBy = didAnyBodyWin(gameState)

    let reward =
      match (gameWonBy, player) with
      | (X, X) | (O, O) -> 1
      | (X, O) | (O, X) -> -1
      | _ -> 0

    (gameState, player, gameWonBy, reward)







