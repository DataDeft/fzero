namespace Fzero

// internal
open Cli
open Logging

//external
open System
open System.Collections

module Main =

  let loggerMain =
    Logger.CreateLogger "Main" "info" (fun () -> DateTime.Now)

  type TicTacToeAtom = X | O | None

  type TicTacToeState = list<TicTacToeAtom>

  let exampleGameStateNone : TicTacToeState =
    [X; O; None; None; None; None; None; None; None]

  let exampleGameStateX : TicTacToeState =
    [X; O; None; X; O; None; X; None; None]



  [<EntryPoint>]
  let main argv =

    let commandLineArgumentsParsed = parseCommandLine (Array.toList argv)

    loggerMain.LogInfo
    <| sprintf "%A" commandLineArgumentsParsed

    0
