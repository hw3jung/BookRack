$ie = new-object -com "InternetExplorer.Application"
$ie.visible = $true

$ie.Navigate("https://fortuna.uwaterloo.ca/cgi-bin/cgiwrap/rsic/book/index.html")

# The easiest way to accomodate for slowness of IE
while($ie.busy) {Start-Sleep 1} 

$doc = $ie.Document

$search_book = $doc.getElementByID("search_box_book")
$button = $search_book.getElementsByClassName("search_button").item(0)

$button.click()

# The easiest way to accomodate for slowness of IE
while($ie.busy) {Start-Sleep 1} 

# This will be our collection of parsed objects
$processedBooks = @()

$index = 0

while(1) {
    $URI = "https://fortuna.uwaterloo.ca/cgi-bin/cgiwrap/rsic/book/scan/MM=da86eb2d0180239bac50b59859ed098c:${index}:" + ($index + 9) + ":10.html?mv_more_ip=1&mv_nextpage=results_books%2ehtml&mv_arg="
    $ie.Navigate($URI)
     
    # The easiest way to accomodate for slowness of IE
    while($ie.busy) {Start-Sleep 1}

    #$HTMLCode = $doc.body.outerHTML
    #Set-Content "C:\Users\HyunWoo\Documents\Scripts\testdownload.htm" $HTMLCode

    # Get a collection of book_item elements
    $books = $doc.body.getElementsByClassName("book_item")

    # Total number of books for a specific page
    $books.length

    # If there are no more books, exit
    if(!$books.length) {break}

    # Iterate through the collection
    for ($i=0; $i -lt $books.length; $i++) {
        # Book
        $item = $books.item($i)

        # Found Book
        1
    
        # Get the author
        $author = $item.getElementsByClassName("author").item(0).outerText

        # Get the title
        $title = $item.getElementsByClassName("title").item(0).outerText

        # TEST: output the author and title to the screen
        $author
        $title

        # Below is PowerShell v3 notation. 
        # In v2, replace '[pscustomobject]' with 
        # 'new-object psobject -Property' 
        $obj = [pscustomobject] @{"author"=$author; 
                                    "title"=$title; }

        $processedBooks += $obj
    }

    $index += 10
}