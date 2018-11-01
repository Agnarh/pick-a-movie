module Movies.Views.MovieListView

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop

open Movies.Types

let movieNameView movie dispatch =
    if movie.IsEditing then
        input [
            Value movie.Name
            // OnChange (fun ev -> EditMovieName (movie.Id, !!ev.target?value) |> dispatch)
            // OnBlur (fun _ -> ToggleEditMovie (movie.Id, false) |> dispatch)
        ]
    else
        str movie.Name

let movieView dispatch movie =
    li [ ClassName "list-group-item" ] [
        div [ ClassName "row justify-content-between" ] [
            div [ ClassName "col-8" ] [
                movieNameView movie dispatch
            ]
            div [ ClassName "col-4" ] [
                div [ ClassName "row justify-content-end" ] [
                    div [
                        ClassName "btn btn-sm"
                        OnClick (fun _ -> 
                            let payload = (movie.Id, not movie.IsEditing)
                            ToggleEditMovie payload |> dispatch)
                    ] [ span [ ClassName "fas fa-edit"] [] ]
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