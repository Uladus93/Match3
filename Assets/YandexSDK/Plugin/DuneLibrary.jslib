mergeInto(LibraryManager.library, {

  SavePlayerScore: function (date) {
	  console.log('SaveGAME!');
    var dateString = UTF8ToString(date);
    var myObj = JSON.parse(dateString);
    player.setData(myObj);
  },
  


  LoadPlayerData: function () {
	  
	  if(player != null)
	  {
				player.getData().then(_date => {
				const myJSON = JSON.stringify(_date);
				myGameInstance.SendMessage('PlayerScore', 'LoadFromJson', myJSON);});
	  }
	  else
	  {
		  myGameInstance.SendMessage('PlayerScore', 'CreateNewGame');
		  myGameInstance.SendMessage('PlayerScore', 'SaveToJson');
	  }
  },
  
  CheckPurchase: function(){
	  if(payments != null)
				{
					payments.getPurchases().then(purchases => purchases.forEach(consumePurchase));
			
					function consumePurchase(purchase) {
						console.log(purchase);
						if (purchase.productID === 'water') {
							myGameInstance.SendMessage('Market', 'PlusSomeBonusesForYans', 17);
						payments.consumePurchase(purchase.purchaseToken);}
							if (purchase.productID === 'bombs') {
							myGameInstance.SendMessage('Market', 'PlusSomeBonusesForYans', 15);
							payments.consumePurchase(purchase.purchaseToken);}
							if (purchase.productID === 'baits') {
							myGameInstance.SendMessage('Market', 'PlusSomeBonusesForYans', 10);
							payments.consumePurchase(purchase.purchaseToken);}
							if (purchase.productID === 'multibonus') {
							myGameInstance.SendMessage('Market', 'PlusSomeBonusesForYans', 200);
							payments.consumePurchase(purchase.purchaseToken);
							}
					}
				}
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
	  if (payments != null)
	  {
		payments.purchase({ id: 'water' }).then(purchase => {
        // Покупка успешно совершена!
		myGameInstance.SendMessage('Market', 'PlusSomeBonusesForYans', value);
		payments.consumePurchase(purchase.purchaseToken);
    }).catch(err => {
        // Покупка не удалась: в консоли разработчика не добавлен товар с таким id,
        // пользователь не авторизовался, передумал и закрыл окно оплаты,
        // истекло отведенное на покупку время, не хватило денег и т. д.
    })
	  }
  },
  
  RocketsYans: function (value) {
	  if (payments != null)
	  {
		payments.purchase({ id: 'bombs' }).then(purchase => {
        // Покупка успешно совершена!
		myGameInstance.SendMessage('Market', 'PlusSomeBonusesForYans', value);
		payments.consumePurchase(purchase.purchaseToken);
    }).catch(err => {
        // Покупка не удалась: в консоли разработчика не добавлен товар с таким id,
        // пользователь не авторизовался, передумал и закрыл окно оплаты,
        // истекло отведенное на покупку время, не хватило денег и т. д.
    })
	  }
  },
  
  BaitsYans: function (value) {
	  if (payments != null)
	  {
		payments.purchase({ id: 'baits' }).then(purchase => {
        // Покупка успешно совершена!
		myGameInstance.SendMessage('Market', 'PlusSomeBonusesForYans', value);
		payments.consumePurchase(purchase.purchaseToken);
    }).catch(err => {
        // Покупка не удалась: в консоли разработчика не добавлен товар с таким id,
        // пользователь не авторизовался, передумал и закрыл окно оплаты,
        // истекло отведенное на покупку время, не хватило денег и т. д.
    })
	  }
  },
  
  MultiplyYans: function (value) {
	  if (payments != null)
	  {
		  payments.purchase({ id: 'multibonus' }).then(purchase => {
        // Покупка успешно совершена!
		myGameInstance.SendMessage('Market', 'PlusSomeBonusesForYans', value);
		payments.consumePurchase(purchase.purchaseToken);
    }).catch(err => {
        // Покупка не удалась: в консоли разработчика не добавлен товар с таким id,
        // пользователь не авторизовался, передумал и закрыл окно оплаты,
        // истекло отведенное на покупку время, не хватило денег и т. д.
    })
	  }
  },
  
  SaveGame: function () {
	  console.log('Save!!!');
	  myGameInstance.SendMessage('PlayerScore', 'SaveToJson');
  },

});