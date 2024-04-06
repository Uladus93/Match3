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
  
  SetToLeaderboard: function (value) {
	    ysdk.getLeaderboards()
  .then(lb => {
    lb.setLeaderboardScore('Spice', value);
  });
  },
  
  GetLanguage: function () {
		var lang = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
	console.log(buffer);
	return buffer;
  },
  
  PlayReclam: function (value) {
		ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
		  myGameInstance.SendMessage('Market', 'PlusSomeBonusesForReclam', value);
		  myGameInstance.SendMessage('PlayerScore', 'SaveToJson');
		  
        },
        onClose: () => {
          console.log('Video ad closed.');
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
  },
  
  WaterYans: function (value) {
		payments.purchase({ id: 'water' }).then(purchase => {
        // Покупка успешно совершена!
		myGameInstance.SendMessage('Market', 'PlusSomeBonusesForYans', value);
		  myGameInstance.SendMessage('PlayerScore', 'SaveToJson');
    }).catch(err => {
        // Покупка не удалась: в консоли разработчика не добавлен товар с таким id,
        // пользователь не авторизовался, передумал и закрыл окно оплаты,
        // истекло отведенное на покупку время, не хватило денег и т. д.
    })
  },
  
  RocketsYans: function (value) {
		payments.purchase({ id: 'bombs' }).then(purchase => {
        // Покупка успешно совершена!
		myGameInstance.SendMessage('Market', 'PlusSomeBonusesForYans', value);
		  myGameInstance.SendMessage('PlayerScore', 'SaveToJson');
    }).catch(err => {
        // Покупка не удалась: в консоли разработчика не добавлен товар с таким id,
        // пользователь не авторизовался, передумал и закрыл окно оплаты,
        // истекло отведенное на покупку время, не хватило денег и т. д.
    })
  },
  
  BaitsYans: function (value) {
		payments.purchase({ id: 'baits' }).then(purchase => {
        // Покупка успешно совершена!
		myGameInstance.SendMessage('Market', 'PlusSomeBonusesForYans', value);
		  myGameInstance.SendMessage('PlayerScore', 'SaveToJson');
    }).catch(err => {
        // Покупка не удалась: в консоли разработчика не добавлен товар с таким id,
        // пользователь не авторизовался, передумал и закрыл окно оплаты,
        // истекло отведенное на покупку время, не хватило денег и т. д.
    })
  },
  
  MultiplyYans: function (value) {
		payments.purchase({ id: 'multibonus' }).then(purchase => {
        // Покупка успешно совершена!
		myGameInstance.SendMessage('Market', 'PlusSomeBonusesForYans', value);
		  myGameInstance.SendMessage('PlayerScore', 'SaveToJson');
    }).catch(err => {
        // Покупка не удалась: в консоли разработчика не добавлен товар с таким id,
        // пользователь не авторизовался, передумал и закрыл окно оплаты,
        // истекло отведенное на покупку время, не хватило денег и т. д.
    })
  },
  
});