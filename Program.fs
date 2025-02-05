open System
open System.Collections.Generic

type LinkedList<'T> =
    | Empty
    | Node of 'T * LinkedList<'T>

let Head =
    function
    | Empty -> failwith "Nie można pobrać głowy."
    | Node(Head,_) -> Head

let Tail =
    function
    | Empty -> failwith "Nie można pobrać ogona"
    | Node(Tail,_) -> Tail

let addHead value list =
    Node(value,list)

let rec printList list = 
    match list with 
    | Empty -> ()
    | Node(value, next) -> 
        printf "%A" value
        printList next // rekurencja



//1. Napisz funkcję, która tworzy listę łączoną na podstawie zwykłej listy (List<'T>).

let rec fromList =
    function
        | [] -> Empty
        | x:: xs ->Node(x,fromList xs)

//2. Napisz funkcję, która sumuje elementy listy zawierającej liczby całkowite.

let rec sumList = 
    function
        | Empty -> 0
        | Node(H,T) -> H + sumList T

// Funkcja do wczytywania listy od uzytkownika

let rec userInputList ()=
    printf "Podaj elementy listy oddzielone spacja: "
    let input = Console.ReadLine()
    let items = 
        input.Split(' ')
        |> Array.choose(fun x ->
            match Int32.TryParse(x) with
            | (true,v) -> Some v
            | _ -> None)
        |> Array.toList
    fromList items

        
    

//3. Napisz funkcję, która znajduje maksymalny i minimalny element w liście liczbowej.

let rec findMax =
    function
        | Empty -> 0
        | Node(H, T) ->
            let maxTail = findMax T
            if H > maxTail then H else maxTail

let rec findMin =
    function
        | Empty -> 0
        | Node(H, T) ->
            let minTail = findMin T
            if H < minTail then H else minTail

//4. Napisz funkcję, która odwraca kolejność elementów listy.


//5. Napisz funkcję, która sprawdza, czy dany element znajduje się w liście.

let rec isInList value list =
    match list with
    | Empty -> false
    | Node(H, T) ->
        if H = value then
            true
        else
            isInList value T

let checkElement list =
    printf "\nPodaj wartośc do sprawdzenia czy wystepuje w liscie: "
    let input = Console.ReadLine()
    let value = Int32.Parse(input)
    if isInList value list then
        printf "\nZnajduje sie w liscie"
    else
        printf "\nNie ma takiego elementu w liscie"
//6. Napisz funkcję, która określi indeks podanego elementu, jeżeli element nie znajduje się na liście
//zwróć odpowiednią wartość (można wykorzystać unie z dyskryminatorem).
//7. Napisz funkcję, która zlicza, ile razy dany element występuje w liście.
//8. Napisz funkcję, która łączy dwie listy łączone w jedną.
//9. Napisz funkcję, która będzie przyjmowała dwie listy liczb całkowitych i zwracała listę wartości
//logicznych, gdzie true określa, że liczba na pierwszej liście była większa, a false, że wartość na
//drugiej liście byłą większa. Jeżeli jednia lista jest dłużna od drugiej zwróć wyjątek informujący o tym
//fakcie.
//10. Napisz funkcję, która zwraca listę zawierającą tylko elementy spełniające określony warunek.
            
            




// Wywołanie funkcji
[<EntryPoint>]
let main argv = 
    let mutable userList = Empty
    userList <- userInputList()
    printf "\nLista podana przez użytkownika: \n"
    printList userList 

    let suma = sumList userList
    let max = findMax userList
    let min = findMin userList
    printf "\nSuma Elementów w podanej liście: %d" suma
    printf "\nNajwiększa wartość w liście: %d" max
    printf "\nNajmniejsza wartość w liście: %d" min
    let checkEl = checkElement userList



    0
