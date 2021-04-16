namespace Fzero

// internal
open Cli
open Logging

//external
open System

module Main =

  let loggerMain =
    Logger.CreateLogger "Main" "info" (fun () -> DateTime.Now)


  [<EntryPoint>]
  let main argv =

    let commandLineArgumentsParsed = parseCommandLine (Array.toList argv)

    loggerMain.LogInfo
    <| sprintf "%A" commandLineArgumentsParsed

    let game = TicTacToe.createGame()

    loggerMain.LogInfo
    <| sprintf "%A" (TicTacToe.step game (Action.Create 4) X)

    loggerMain.LogInfo
    <| sprintf "%A" (TicTacToe.step game (Action.Create 0) O)

    loggerMain.LogInfo
    <| sprintf "%A" (TicTacToe.step game (Action.Create 5) X)

    loggerMain.LogInfo
    <| sprintf "%A" (TicTacToe.step game (Action.Create 1) O)

    loggerMain.LogInfo
    <| sprintf "%A" (TicTacToe.step game (Action.Create 3) X)


    0
