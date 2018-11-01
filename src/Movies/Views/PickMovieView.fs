module Movies.Views.PickMovieView

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Movies.Types

let getRandomIndex range =
    let rnd = new System.Random()
    range |> rnd.Next

let rec getDifferentMovie pickedMovie movies =
    let movie = movies |> List.item (getRandomIndex movies.Length)
    match pickedMovie with
    | Some _pickedMovie when (_pickedMovie.Id = movie.Id && movies.Length > 1) -> getDifferentMovie pickedMovie movies
    | Some _ | None-> movie

let pickMovie state dispatch =
    if state.MovieList.Length > 0 then
        state.MovieList
        |> getDifferentMovie state.PickedMovie
        |> fun movie -> movie.Id
        |> PickMovie
        |> dispatch
    else
        ()

let pickMovieView state dispatch =
    let pickMovieName =
        match state.PickedMovie with
        | Some movie -> movie.Name
        | None -> ""

    div [ ClassName "pick-movie-wrapper" ] [
        div [ ClassName "row justify-content-center" ] [
            button [
                Disabled (state.MovieList.Length = 0)
                ClassName "btn btn-outline-secondary"
                OnClick (fun _ -> pickMovie state dispatch)
            ] [
                str "Pick Movie"
            ]
        ]
        h1 [ ClassName "row justify-content-center text-primary" ] [
            str pickMovieName
        ]
    ]