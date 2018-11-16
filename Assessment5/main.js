$(document).ready(function() {
    const questionBank = [
        {
            Name: `What is your name?`,
            Options: [
                {
                    Value: 'Blake',
                    Correct: true
                },
                {
                    Value: 'Lin-z',
                    Correct: false
                },
                {
                    Value: 'Taylor',
                    Correct: false
                }
            ]
        },
        {
            Name: `What is your quest?`,
            Options: [
                {
                    Value: 'Get more coins',
                    Correct: false
                },
                {
                    Value: 'Find more bananas',
                    Correct: false
                },
                {
                    Value: 'Seek the holy grail',
                    Correct: true
                }
            ]
        },
        {
            Name: `What is your favorite color?`,
            Options: [
                {
                    Value: 'Blue',
                    Correct: false
                },
                {
                    Value: 'Yellow',
                    Correct: true
                },
                {
                    Value: 'Green',
                    Correct: false
                }
            ]
        },
        {
            Name: `What is the capital of Assyria?`,
            Options: [
                {
                    Value: 'Babylon',
                    Correct: false
                },
                {
                    Value: 'Assur',
                    Correct: true
                },
                {
                    Value: 'Nineveh',
                    Correct: false
                }
            ]
        }
    ]

    let right = 0

    function setQuestion(questionNumber){
        const question = questionBank[questionNumber]
        $('#question').text(question.Name)
        $('#answers').empty()
        for(i=0;i<question.Options.length;i++){
            $('#answers').append(`<button class="${question.Options[i].Correct}" type="button">${question.Options[i].Value}</button>`)
        }
        $('#answers button').click({questionNumber:questionNumber}, getQuestionNumber)
    }

    function checkQuestion(questionNumber, correct){
        if(correct=='true'){
            right++
            console.log(right)
            alert("Correct")
        }else{
            alert("Incorrect")
        }
        if(questionNumber < questionBank.length-1) {
            setQuestion(questionNumber+1)
        } else {
            finalText = `
            That's all folks!
            Right: ${right}
            Wrong: ${4-right}
            `
            $('#questionBox').empty().text(finalText)
        }  
    }

    function getQuestionNumber(event){
        checkQuestion(event.data.questionNumber, event.target.className)
    }

    setQuestion(0)
});