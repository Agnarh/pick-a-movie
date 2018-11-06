module Movies.Views.MovieListView

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop

open Movies.Types

let newMovieNameHandler id dispatch newName =
    if not (System.String.IsNullOrEmpty newName) then
        EditMovieName (id, newName) |> dispatch
    else
        ()
    ToggleEditMovie (id, false) |> dispatch

let movieNameView movie dispatch =
    let handler = newMovieNameHandler movie.Id dispatch

    if movie.IsEditing then
        input [
            DefaultValue movie.Name
            AutoFocus true
            OnBlur (fun ev -> !!ev.target?value |> handler)
            OnKeyDown (fun ev ->
                match ev.keyCode with
                | 13. -> !!ev.target?value |> handler
                | _ -> ())
        ]
    else
        span [ ClassName "movie-item-name" ] [ str movie.Name ]

let editIconView movie dispatch =
    if movie.IsEditing then
        div [] []
    else
        div [
            ClassName "btn btn-sm"
            OnClick (fun _ -> 
                let payload = (movie.Id, not movie.IsEditing)
                ToggleEditMovie payload |> dispatch)
        ] [ span [ ClassName "fas fa-edit"] [] ]

let movieView dispatch movie =
    li [ ClassName "list-group-item" ] [
        div [ ClassName "row justify-content-between" ] [
            div [ ClassName "col-8" ] [
                movieNameView movie dispatch
            ]
            div [ ClassName "col-4" ] [
                div [ ClassName "row justify-content-end" ] [
                    editIconView movie dispatch
                    div [
                        ClassName "btn btn-sm"
                        OnClick (fun _ -> DeleteMovie movie.Id |> dispatch)
                    ] [ span [ ClassName "fas fa-trash-alt"] [] ]
                ]
            ]
        ]
    ]

let movieListView movies dispatch =
    div [ ClassName "movie-list-wrapper" ] [
        ul [ ClassName "list-group" ] (movies |> List.map (movieView dispatch))
    ]