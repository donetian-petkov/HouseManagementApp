function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}

ps 39028;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 39028 > /dev/null;
done;

for child in $(list_child_processes 39030);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/donetianpetkov/Documents/GitHub/HouseManagementApp/HouseManagementApp/bin/Debug/net6.0/4b6282a8e28543d7a5c651b8bd6206e7.sh;
