mergeInto(LibraryManager.library, {

  RateTheGame: function () {
    ysdk.feedback.canReview()
    .then(({ value, reason }) => {
      if (value) {
        ysdk.feedback.requestReview()
        .then(({ feedbackSent }) => {
          console.log(feedbackSent);
        })
      } else {
        console.log(reason)
      }
    })
  },

  SetPlayerData: function () {
    myGameInstance.SendMessage('YandexSDK', 'SetName', player.getName());
    myGameInstance.SendMessage('YandexSDK', 'SetAvatar', player.getPhoto("medium"));
  },

  SavePlayerScore: function (date) {
    var dateString = UTF8ToString(date);
    var myObj = JSON.parse(dateString);
    player.setData(myObj);
  },

  LoadPlayerData: function () {
    player.getData().then(_date => {
      const myJSON = JSON.stringify(_date);
      myGameInstance.SendMessage('PlayerScore', 'LoadFromJson', myJSON);
      console.log(myJSON);
    })
  },

});