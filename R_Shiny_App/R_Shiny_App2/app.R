library(shiny)
mydata = read.csv("data/clashData.csv") # read csv file
ui <- fluidPage(
# Give the page a title
titlePanel("Card Usage At The Top Of The Ladder"),

  # Generate a row with a sidebar
sidebarLayout(

#clashData <<- clashData,
    # Define the sidebar with one input
    sidebarPanel(
      selectInput("region", "Region:",
                  choices = colnames(mydata)),
      hr(),
      helpText("Data from Woody's Snapshots via Reddit.")
    ),

    # Create a spot for the barplot
    mainPanel(
      plotOutput("phonePlot")
    )

  )
    )

server <- function(input, output) {

   # clashData <<- clashData
    # Fill in the spot we created for a plot
    output$phonePlot <- renderPlot({

        # Render a barplot
    barplot(mydata[, input$region],
            main = input$region,
            ylab = "# Used in Top 100 Decks",
            xlab = "Snapshot #")
  })
}

shinyApp(ui = ui, server = server)